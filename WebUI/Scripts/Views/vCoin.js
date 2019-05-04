
function vCoin() {

	//todo lo que esta aqui rige para la vista de vCoin

	this.tblCoinId = 'tblCoin';
	this.service = 'coin';
	this.ctrlActions = new ControlActions();
	this.columns = "CoinName,Amount,Symbol,Status";
     var view = window.location.href;
     var dataModify = JSON.parse(sessionStorage.getItem(this.tblCoinId+"_selected"));
     
	this.RetrieveAll = function () {
		sessionStorage.removeItem(this.tblCoinId+'_selected');
        this.ctrlActions.FillTable(this.service, this.tblCoinId, false,  '/Dashboard/modifyCoin');
	}


	//PostToApi hace un envia Ajax de la informacion a nuestra API para que se almacena en la base de datos
	//postToApi recibe dos parametros: el servicio que se va a ejecutar, en este caso Coin y la data que se va a guardar
	this.Create = function () {
		var coinData = {};
		coinData = this.ctrlActions.GetDataForm('frmEdition');
        
        if (!coinData) {
            return false;
        }
        coinData.Status = "Activo";
		$.post(this.ctrlActions.GetUrlApiService(this.service), coinData, function (response) {            
            Swal.fire({
                title: 'Coin created! ',
               type: 'success',
                confirmButtonColor: '#3085d6',
                confirmButtonText: 'Ok'
             }).then((result) => {
                   window.location.href = '/Dashboard/listCoin';
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

	this.Update = function () {
		var coinData = this.ctrlActions.GetDataForm('frmEditionModify');
        
         if (!coinData) {
            return false;
        }
       $.put(this.ctrlActions.GetUrlApiService(this.service), coinData, function (response) {            
            Swal.fire({
                title: 'Coin modified! ',
               type: 'success',
                confirmButtonColor: '#3085d6',
                confirmButtonText: 'Ok'
             }).then((result) => {
                   window.location.href = '/Dashboard/listCoin';
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
    
    this.ObtenerInformacion = function () {
        this.ctrlActions.BindFields('frmEditionModify', dataModify);
    }
}

//ON DOCUMENT READY
$(document).ready(function () {

	var vcoin = new vCoin();
    
    if ($('#tblCoin').length) {
        vcoin.RetrieveAll();
    }
    
    if (window.location.href.includes('modifyCoin')) {
        vcoin.ObtenerInformacion();
    }
});

