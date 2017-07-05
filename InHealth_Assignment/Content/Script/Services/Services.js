//'use strict';
////var webApiBaseUrl = "http://localhost:10611/api/";
//var inHealthAssignmentService = angular.module('inHealthAssignmentApp.AppServices', ['ngResource']);

//inHealthAssignmentService = angular.module('inHealthAssignmentApp.AppServices').service('LocalData', [function () {
//    this.SetClass = function (pageId, stageId) {
//        if (pageId == undefined && stageId == undefined) {
//            var setClass = new Object();
//            setClass.ForHR = "btn-warning";
//            setClass.ForCMO = "btn-default";
//            setClass.ForFD = "btn-default";
//            setClass.ForID = "btn-default";
//            setClass.ForIT = "btn-default";
//            return setClass;
//        }
//        else if (pageId <= stageId) {
//            var setClass = new Object();
//            setClass.ForHR = "btn-success";
//            setClass.ForCMO = "btn-default";
//            setClass.ForFD = "btn-default";
//            setClass.ForID = "btn-default";
//            setClass.ForIT = "btn-default";

//            if (stageId == null || stageId == 1) {
//                setClass.ForHR = "btn-warning";
//                return setClass;
//            }
//            else if (stageId == 5) {
//                setClass.ForCMO = "btn-success";
//                setClass.ForFD = "btn-success";
//                setClass.ForID = "btn-success";
//                setClass.ForIT = "btn-success";
//            }
//            else if (stageId >= 4) {
//                setClass.ForCMO = "btn-success";
//                setClass.ForFD = "btn-success";
//                setClass.ForID = "btn-success";
//            }
//            else if (stageId >= 3) {
//                setClass.ForCMO = "btn-success";
//                setClass.ForFD = "btn-success";
//            }
//            else if (stageId >= 2) {
//                setClass.ForCMO = "btn-success";
//            }
//            else {
//                toastr.warning("No permission to go inside this tab");
//            }
//            return setClass;
//        }
//        else {
//            toastr.warning("Entered URL is invalid!! Please enter correct URL!!");
//        }
//    }
//    var details = new Object();
//    this.GetDetails = function () {
//        return details;
//    }

//    this.SetDetails = function (stageId, billingCode) {
//        details.StageId = stageId;
//        details.BillingCode = billingCode;
//    }
//}]);