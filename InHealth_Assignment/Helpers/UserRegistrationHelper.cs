using InHealth_Assignment.Business;
using InHealth_Assignment.Model.Entities;
using InHealth_Assignment.Web.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InHealth_Assignment.Web.Helpers
{
    public class UserRegistrationHelper
    {
        #region "Member Declaration"
        public readonly GenericService _genericService = null;
        #endregion

        #region "Constructor"
        public UserRegistrationHelper()
        {
            _genericService = new GenericService();
        }
        #endregion

        #region "Public Methods"
        public ReturnResult SaveUserRegistrationData(UserRegistrationVM userRegistrationVM)
        {
            ReturnResult returnResult = new ReturnResult();
            returnResult.Success = false;
            try
            {
                UserRegistration _userRegistration = new UserRegistration();
                _userRegistration.fName = userRegistrationVM.First_Name;
                _userRegistration.lName = userRegistrationVM.Last_Name;
                _userRegistration.emailId = userRegistrationVM.EmailId;
                _userRegistration.password = Utilities.utility.Encryptpassword(userRegistrationVM.Password);
                _userRegistration.CreatedDate = DateTime.Now;
                _userRegistration.roleId = GetRoleId();
                _userRegistration.IsActive = true;

                //Validate Unique emailId
                if (!ValidateUniqueEmailId(userRegistrationVM.EmailId))
                {
                    returnResult.Success = false;
                    returnResult.Message = "EmailId already exist!!!";
                    return returnResult;
                }

                _genericService.UserRegistration.Insert(_userRegistration);
                _genericService.Commit();

                if(_userRegistration==null)
                {
                    returnResult.Success = false;
                    returnResult.Message = "Error occured!!!";
                }
                else
                {
                    returnResult.UserId = _userRegistration.Id;
                    returnResult.Success = true;
                    returnResult.Message = "Registration completed successfully!!!";
                }
            }
            catch(Exception ex) {
                throw new Exception(ex.ToString());
            }
            return returnResult;
        }
        public UserRegistrationListVM GetRegisteredUserData()
        {
            UserRegistrationListVM _userRegistrationListVM = new UserRegistrationListVM();
            List<UserRegistrationVM> _userRegistrationVM = new List<UserRegistrationVM>();

            IQueryable<UserRegistrationVM> _userList;

            _userList = _genericService.UserRegistration.GetAll().Where(x => x.IsActive == true).Select(x => new UserRegistrationVM
            {
                userId = x.Id,
                First_Name = x.fName,
                Last_Name = x.lName,
                EmailId = x.emailId,
                RoleName = x.UserRole.RoleName,
                RoleId = x.roleId
            });

            _userRegistrationListVM.userRegistrationList = _userList.ToList();
            _userRegistrationListVM.TotalCount = _userList.Count();
            return _userRegistrationListVM;
        }
        public ReturnResult UpdateUserRole(UserRegistrationVM userRegistrationVM)
        {
            ReturnResult _ReturnResult = new ReturnResult();

            var userData = _genericService.UserRegistration.GetAll().Where(x => x.Id == userRegistrationVM.userId).FirstOrDefault();
            var _roleId = _genericService.UserRole.GetAll().Where(x => x.RoleName.ToLower() == "admin").FirstOrDefault().roleId;
            userData.roleId = _roleId;

            _genericService.UserRegistration.Update(userData);
            _genericService.Commit();

            if(userData==null)
            {
                _ReturnResult.Success = false;
                _ReturnResult.Message = "Error occured!!!";
            }
            else
            {
                _ReturnResult.Success = true;
                _ReturnResult.Message = "Role updated successfully!!!";
            }
            return _ReturnResult;
        }
        public ReturnResult DeleteUser(UserRegistrationVM userRegistrationVM)
        {
            ReturnResult _ReturnResult = new ReturnResult();

            var userData = _genericService.UserRegistration.GetAll().Where(x => x.Id == userRegistrationVM.userId).FirstOrDefault();
            userData.IsActive = false;

            _genericService.UserRegistration.Update(userData);
            _genericService.Commit();

            if (userData == null)
            {
                _ReturnResult.Success = false;
                _ReturnResult.Message = "Error occured!!!";
            }
            else
            {
                _ReturnResult.Success = true;
                _ReturnResult.Message = "User deleted successfully!!!";
            }
            return _ReturnResult;
        }
        #endregion

        #region "Private Methods"
        private int GetRoleId()
        {
            int roleId = 0;
            var userCount = _genericService.UserRegistration.GetAll().Count();

            roleId= userCount == 0? roleId = _genericService.UserRole.GetAll().Where(x => (x.IsActive==true && x.RoleName.ToLower() == "admin")).FirstOrDefault().roleId:
                                             _genericService.UserRole.GetAll().Where(x => (x.IsActive==true && x.RoleName.ToLower() == "standard user")).FirstOrDefault().roleId;
            return roleId;
        }
       
        private bool ValidateUniqueEmailId(string _emailId)
        {
            var userData = _genericService.UserRegistration.GetAll().Where(x => x.IsActive == true && x.emailId.ToLower() == _emailId.ToLower());
            return userData.Any() == true ? false : true;
        }

    #endregion

}
}