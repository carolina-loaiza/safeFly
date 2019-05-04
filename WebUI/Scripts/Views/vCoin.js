
function vCoin() {

	//todo lo que esta aqui rige para la vista de vCoin

	this.tblCoinId = 'tblCoin';
	this.service = 'coin';
	this.ctrlActions = new ControlActions();
	this.columns = "CoinName,Amount,Symbol,Status";

	this.RetrieveAll = function () {
		this.ctrlActions.FillTable(this.service, this.tblCoinId, false);
	}

	this.ReloadTable = function () {
		this.ctrlActions.FillTable(this.service, this.tblCoinId, true);
	}

	//PostToApi hace un envia Ajax de la informacion a nuestra API para que se almacena en la base de datos
	//postToApi recibe dos parametros: el servicio que se va a ejecutar, en este caso Coin y la data que se va a guardar
	this.Create = function () {
		var coinData = {};
		coinData = this.ctrlActions.GetDataForm('frmEdition');
		//Hace el post al create
		this.ctrlActions.PostToAPI(this.service, coinData);
		Swal.fire({
			title: 'Creation completed',
			text: 'The coin has been created successfully',
			type: 'success',
			confirmButtonText: 'Got it!'
		});
		//Refresca la tabla
		this.ReloadTable();
	}

	this.Update = function () {

		var coinData = {};
		coinData = this.ctrlActions.GetDataForm('frmEdition');
		//Hace el post al create
		this.ctrlActions.PutToAPI(this.service, coinData);
		Swal.fire({
			title: 'Update completed',
			text: 'The coin has been updated successfully',
			type: 'success',
			confirmButtonText: 'Got it!'
		});
		//Refresca la tabla
		this.ReloadTable();

	}

	this.Delete = function () {

		var coinData = {};
		coinData = this.ctrlActions.GetDataForm('frmEdition');
		//Hace el post al create
		this.ctrlActions.DeleteToAPI(this.service, coinData);
		Swal.fire({
			title: 'Deactivation completed',
			text: 'The coin has been deactivated successfully',
			type: 'sucess',
			confirmButtonText: 'Got it!'
		});
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

	var vcoin = new vCoin();
	vcoin.RetrieveAll();

});

