function vCreateAdminAirport() {

	this.tblCreateAdminAirportId = 'tblCreateAdminAirport';
    this.service = 'airportAdmin';  //backend --- PENDING
    this.ctrlActions = new ControlActions();
    this.columns = "ID,FirstName,SecondName,LastName1,LastName2,Email,BirthDate,PhoneNumber,Status,NameAirport";

    this.RetrieveAll = function () {
		this.ctrlActions.FillTable(this.service, this.tblCreateAdminAirportId, false);
    }

    this.ReloadTable = function () {
		this.ctrlActions.FillTable(this.service, this.tblCreateAdminAirportId, true);
    }

    this.Create = function () {
		var createAdminAirportData = {};
        createAdminAirportData = this.ctrlActions.GetDataForm('frmEdition');
        //Hace el post al create
		this.ctrlActions.PostToAPI(this.service, createAdminAirportData);
        //Refresca la tabla
        this.ReloadTable();
    }

    this.Update = function () {

		var createAdminAirportData = {};
        createAdminAirportData = this.ctrlActions.GetDataForm('frmEdition');
        //Hace el post al create
		this.ctrlActions.PutToAPI(this.service, createAdminAirportData);
        //Refresca la tabla
        this.ReloadTable();

    }

    this.Delete = function () {

		var createAdminAirportData = {};
		createAdminAirportData = this.ctrlActions.GetDataForm('frmEdition');
        //Hace el post al create
		this.ctrlActions.DeleteToAPI(this.service, createAdminAirportData);
        //Refresca la tabla
        this.ReloadTable();

    }

    this.BindFields = function (data) {
        this.ctrlActions.BindFields('frmEdition', data);
    }
}

//ON DOCUMENT READY
$(document).ready(function () {

	var vcreateAdminAirport = new vCreateAdminAirport();
	vcreateAdminAirport.RetrieveAll();

});
