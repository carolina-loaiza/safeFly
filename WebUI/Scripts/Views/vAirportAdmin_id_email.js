
function vAirportAdmin_id_email() {

	//todo lo que esta aqui rige para la vista de vCoin

	this.tblvAirportAdmin_id_emailId = 'tblvAirportAdmin_id_email';
	this.service = 'user/ID_email';
	this.ctrlActions = new ControlActions();
	this.columns = "ID,Email";

	this.RetrieveAll = function () {
		this.ctrlActions.FillTable(this.service, this.tblvAirportAdmin_id_emailId, false);
	}

	this.ReloadTable = function () {
		this.ctrlActions.FillTable(this.service, this.tblvAirportAdmin_id_emailId, true);
	}

	//PostToApi hace un envia Ajax de la informacion a nuestra API para que se almacena en la base de datos
	//postToApi recibe dos parametros: el servicio que se va a ejecutar, en este caso Coin y la data que se va a guardar
	this.Create = function () {
		var airportAdmin_id_emailData = {};
		airportAdmin_id_emailData = this.ctrlActions.GetDataForm('frmEdition');
		//Hace el post al create
		this.ctrlActions.PostToAPI(this.service, airportAdmin_id_emailData);
		//Refresca la tabla
		this.ReloadTable();
	}

	this.Update = function () {

		var airportAdmin_id_emailData = {};
		airportAdmin_id_emailData = this.ctrlActions.GetDataForm('frmEdition');
		//Hace el post al create
		this.ctrlActions.PutToAPI(this.service, airportAdmin_id_emailData);
		//Refresca la tabla
		this.ReloadTable();

	}

	this.Delete = function () {

		var airportAdmin_id_emailData = {};
		airportAdmin_id_emailData = this.ctrlActions.GetDataForm('frmEdition');
		//Hace el post al create
		this.ctrlActions.DeleteToAPI(this.service, airportAdmin_id_emailData);
		//Refresca la tabla
		this.ReloadTable();

	}


	//lo que hace es llamar a una funicion de crtlActions (el papa de todos los js)
	// le manda dos parametros, un id de formulario (frmEdition) y data
	// asi se muestra en el form 
	this.BindFields = function (data) {
		this.ctrlActions.BindFields('frmEdition', data);
	}
}

//ON DOCUMENT READY
$(document).ready(function () {

	var vairportAdmin_id_email = new vAirportAdmin_id_email();
	vairportAdmin_id_email.RetrieveAll();

});

