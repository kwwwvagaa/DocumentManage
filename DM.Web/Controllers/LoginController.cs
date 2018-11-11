using DM.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DM.Domain;
using DM.Interface.IService;
using DM.Tools.Log;

namespace DM.Web.Controllers
{
    public class LoginController : Controller
    {
        ISys_UserService m_userService = null;
        ISys_LogService m_logService = null;
        public LoginController(ISys_UserService userService, ISys_LogService logService)
        {
            m_userService = userService;
            m_logService = logService;
        }
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 功能描述:获取验证码
        /// 作　　者:黄正辉
        /// 创建日期:2018-11-08 21:10:46
        /// 任务编号:档案管理系统
        /// </summary>
        /// <returns>返回值</returns>
        public ActionResult GetAuthCode()
        {
            return File(new VerifyCode().GetVerifyCode(), @"image/Gif");
        }
        public ActionResult OutLogin()
        {
            Sys_Log logEntity = new Sys_Log()
            {
                F_ModuleName = "系统登录",
                F_Type = DbLogType.Exit.ToString(),
                F_Account = OperatorProvider.Provider.GetCurrent().UserCode,
                F_NickName = OperatorProvider.Provider.GetCurrent().UserName,
                F_Result = true,
                F_Description = "安全退出系统",
            };
            m_logService.WriteDbLog(logEntity);
            Session.Abandon();
            Session.Clear();
            OperatorProvider.Provider.RemoveCurrent();
            return RedirectToAction("Index", "Login");
        }
        [HttpPost]
        [HandlerAjaxOnly]
        public ActionResult CheckLogin(string username, string password, string code)
        {
            Sys_Log logEntity = new Sys_Log();
            logEntity.F_ModuleName = "系统登录";
            logEntity.F_Type = DbLogType.Login.ToString();
            try
            {
                if (Session["dm_session_verifycode"].IsEmpty() || Md5.md5(code.ToLower(), 16) != Session["dm_session_verifycode"].ToString())
                {
                    throw new Exception("验证码错误，请重新输入");
                }

                Sys_User userEntity = m_userService.CheckLogin(username, password);
                if (userEntity != null)
                {
                    OperatorModel operatorModel = new OperatorModel();
                    operatorModel.UserId = userEntity.F_Id;
                    operatorModel.UserCode = userEntity.F_Account;
                    operatorModel.UserName = userEntity.F_RealName;
                    operatorModel.CompanyId = userEntity.F_OrganizeId;
                    operatorModel.DepartmentId = userEntity.F_DepartmentId;
                    operatorModel.RoleId = userEntity.F_RoleId;
                    operatorModel.LoginIPAddress = Net.Ip;
                    operatorModel.LoginIPAddressName = Net.GetLocation(operatorModel.LoginIPAddress);
                    operatorModel.LoginTime = DateTime.Now;
                    operatorModel.LoginToken = DESEncrypt.Encrypt(Guid.NewGuid().ToString());
                    if (userEntity.F_Account == "admin")
                    {
                        operatorModel.IsSystem = true;
                    }
                    else
                    {
                        operatorModel.IsSystem = false;
                    }
                    OperatorProvider.Provider.AddCurrent(operatorModel);
                    logEntity.F_Account = userEntity.F_Account;
                    logEntity.F_NickName = userEntity.F_RealName;
                    logEntity.F_Result = true;
                    logEntity.F_Description = "登录成功";
                    m_logService.WriteDbLog(logEntity);
                }
                return Content(new AjaxResult { state = ResultType.success.ToString(), message = "登录成功。" }.ToJson());
            }
            catch (Exception ex)
            {
                logEntity.F_Account = username;
                logEntity.F_NickName = username;
                logEntity.F_Result = false;
                logEntity.F_Description = "登录失败，" + ex.Message;
                m_logService.WriteDbLog(logEntity);
                return Content(new AjaxResult { state = ResultType.error.ToString(), message = ex.Message }.ToJson());
            }
        }
    }
}