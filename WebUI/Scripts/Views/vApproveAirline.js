
function vApproveAirline() {

	//todo lo que esta aqui rige para la vista de vCoin

	this.tblApproveAirlineId = 'tblApproveAirline';
	this.service = 'approveAirline';  
	this.ctrlActions = new ControlActions();
	this.columns = "ID,Name,BusinessName,Admin,Email,PhoneNumber,RepresentantLegal,InscriptionDate,Approvement,Status";


	this.RetrieveAll = function () {
		this.ctrlActions.FillTable(this.service, this.tblApproveAirlineId, false);
	}

	this.ReloadTable = function () {
		this.ctrlActions.FillTable(this.service, this.tblApproveAirlineId, true);
	}

	this.Create = function () {
		var approvalAirlineData = {};
		approvalAirlineData = this.ctrlActions.GetDataForm('frmEdition');
		//Hace el post al create
		this.ctrlActions.PostToAPI(this.service, approvalAirlineData);
		//Refresca la tabla
		this.ReloadTable();
	}

	this.Update = function () {

		var approvalAirlineData = {};
		approvalAirlineData = this.ctrlActions.GetDataForm('frmEdition');
		//Hace el post al create
		this.ctrlActions.PutToAPI(this.service, approvalAirlineData);
		//Refresca la tabla
		this.ReloadTable();

	}

	this.Delete = function () {

		var approvalAirlineData = {};
		approvalAirlineData = this.ctrlActions.GetDataForm('frmEdition');
		//Hace el post al create
		this.ctrlActions.DeleteToAPI(this.service, approvalAirlineData);
		//Refresca la tabla
		this.ReloadTable();

	}

	this.BindFields = function (data) {
		this.ctrlActions.BindFields('frmEdition', data);
	}
}

//ON DOCUMENT READY
$(document).ready(function () {

	var vapproveAirline = new vApproveAirline();
	vapproveAirline.RetrieveAll();

});

