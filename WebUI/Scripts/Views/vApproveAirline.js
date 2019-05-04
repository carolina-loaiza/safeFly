
function vApproveAirline() {

	//todo lo que esta aqui rige para la vista de vCoin

	var tblApproveAirlineId = 'tblApproveAirline';
	var service = 'Airline/AllApproval/airportID/Inactivo';  
	this.ctrlActions = new ControlActions();
	this.columns = "ID,Name,BusinessName,Admin,Email,PhoneNumber,RepresentantLegal,InscriptionDate,Approvement,Status";
    var userLogin = JSON.parse(sessionStorage.getItem("user"));
    var CtrlActions = new ControlActions();


	this.RetrieveAll = function () {
       $.get(this.ctrlActions.GetUrlApiService('Airport/ByAdminID/'+userLogin.ID), function (response) {     
             service = service.replace(/airportID/i, response.Data.LegalNumber);
            CtrlActions.FillTable(service, tblApproveAirlineId, false, false); 
        })
     }
    
	this.Update = function () {

		var approvalAirlineData = JSON.parse(sessionStorage.getItem('tblApproveAirline_selected'));
        $.put(this.ctrlActions.GetUrlApiService('approveAirline'), approvalAirlineData, function (response) {            
            Swal.fire({
                title: 'Airline approved! ',
               type: 'success',
                confirmButtonColor: '#3085d6',
                confirmButtonText: 'Ok'
             }).then((result) => {
                   window.location.href = '/Dashboard/listAirline';
              })
        })
        .fail(function (response) {
               Swal.fire({
                    title: 'An error has occurred',
                    text: 'Please check the information and try again.',
                   type: 'error',
                    confirmButtonText: 'OK'
               });
         })
	}
}

//ON DOCUMENT READY
$(document).ready(function () {

	var vapproveAirline = new vApproveAirline();
	vapproveAirline.RetrieveAll();

});

