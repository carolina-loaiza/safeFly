function vAirport() {

    this.tblAirportId = "tblAirports";
    this.service = "Airport";
    this.serviceActivate = "Airport/Activar";
    this.ctrlActions = new ControlActions();
    this.columns = "LegalNumber,NameAirport,BusinessName,Administrator,Email,Latitude,Longitude,Representative,RepresentativeID,Estado";
     var view = window.location.href;
     var dataModify = JSON.parse(sessionStorage.getItem(this.tblAirportId+"_selected"));
      var airportAdminWithoutAirport = "AirportAdmin/withoutAirport";
      var userLogin = JSON.parse(sessionStorage.getItem("user"));
      var CtrlActions = new ControlActions();
    
    this.SetInformation = function () {
        window.location.href = '/Dashboard/createAirport';
    }
    
    this.RetrieveAllAirportAdmin = function () {
        if (userLogin.RolName != 'AdminAeropuerto') {
            $.get(this.ctrlActions.GetUrlApiService(airportAdminWithoutAirport), function (response) { 
                response.Data.forEach(function(element) { 
                   $('#txtAdministrator').append("<option value="+element.ID+">"+element.FirstName + " "+  element.LastName1+"</option>");  
                })
                
                if (view.includes('modifyAirport')) {
                     $('#txtAdministrator').append("<option value="+dataModify.Administrator+">dataModify.Administrator</option>");
                     $("#txtAdministrator").val(dataModify.Administrator)
                } 
            })
        } else {
            $('#txtAdministrator').addClass('d-none');
        }
    }
    
    this.RetrieveListAirportAdmin = function () {
        this.ctrlActions.FillTable('AirportAdmin/all', 'tblistAdminAirport', false,  false);
    }

    this.RetrieveAll = function () {
        sessionStorage.removeItem(this.tblAirportId+'_selected');
        var link = userLogin.RolName != "SysAdmin" ?  false : '/Dashboard/modifyAirport';
        
        if (userLogin.RolName == 'AdminAerolinea') { 
            var ctrlActions =  this.ctrlActions;
           $.get(this.ctrlActions.GetUrlApiService('Airline/ByAdminID/'+userLogin.ID), function (response) {            
                var service = 'Airport/AllApproval/'+response.Data.ID+'/Activo';
                ctrlActions.FillTable(service, 'tblAirports', false,  false);
            })
        } else {
            this.ctrlActions.FillTable(this.service, this.tblAirportId, false,  link);
        }
    }


    this.Create = function () {
        var airportData = {};
        airportData = this.ctrlActions.GetDataForm('frmEdition');
         if (!airportData) {
            return false;
        }
        $.post(this.ctrlActions.GetUrlApiService(this.service), airportData, function (response) {            
            Swal.fire({
                title: 'Airport created! ',
               type: 'success',
                confirmButtonColor: '#3085d6',
                confirmButtonText: 'Ok'
             }).then((result) => {
                   window.location.href = '/Dashboard/listAirport';
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
         var airportDataModify = this.ctrlActions.GetDataForm('frmEditionModify');
         if (!airportDataModify) {
            return false;
        }
       $.put(this.ctrlActions.GetUrlApiService(this.service), airportDataModify, function (response) {            
            Swal.fire({
                title: 'Airport modified! ',
               type: 'success',
                confirmButtonColor: '#3085d6',
                confirmButtonText: 'Ok'
             }).then((result) => {
                 if (userLogin.RolName == 'AdminAeropuerto') {
                    window.location.reload();
                 } else {
                   window.location.href = '/Dashboard/listAirport';
                 }
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

        var airportData = {};
        airportData = this.ctrlActions.GetDataForm('frmEdition');
        //Hace el post al create
        this.ctrlActions.DeleteToAPI(this.service, airportData);
        Swal.fire({
            title: 'Desactivación correcta',
            text: 'El aeropuerto se desactivo correctamente',
            type: 'sucess',
            confirmButtonText: 'Entendido'
        });
        //Refresca la tabla
        this.ReloadTable();

    }

    this.Activar = function () {

        var airportData = {};
        airportData = this.ctrlActions.GetDataForm('frmEdition');
        //Hace el post al create
        this.ctrlActions.ActivarToAPI(this.serviceActivate, airportData);
        Swal.fire({
            title: 'Activación completa',
            text: 'El aeropuerto se activo correctamente',
            type: 'success',
            confirmButtonText: 'Entendido'
        });
        //Refresca la tabla
        this.ReloadTable();

    }

    this.BindFields = function (data) {
        this.ctrlActions.BindFields('frmEdition', data);
        sessionStorage.setItem('airportData', JSON.stringify(data));
    }

    this.ObtenerInformacion = function () {
        if (userLogin.RolName == 'AdminAeropuerto') {
        var ctrlActions =  this.ctrlActions;
           $.get(this.ctrlActions.GetUrlApiService('Airport/ByAdminID/'+userLogin.ID), function (response) {            
                ctrlActions.BindFields('frmEditionModify', response.Data);
                $('#txtAdministrator').append("<option value="+response.Data.Administrator+">dataModify.Administrator</option>");
                $("#txtAdministrator").val(response.Data.Administrator)
            })
        } else {
            this.ctrlActions.BindFields('frmEditionModify', dataModify);
        };
        $("#txtLegalNumber").prop("disabled", true); //Disable
        $("#txtRepresentativeID").prop("disabled", true); //Disable
    }
 
}

//ON DOCUMENT READY
$(document).ready(function () {

    var vairport = new vAirport();

    if ($('#tblAirports').length) {
        vairport.RetrieveAll();
    }
    
    if ($('#txtAdministrator').length) {
        vairport.RetrieveAllAirportAdmin();
    }
    
    if (window.location.href.includes('modifyAirport')) {
        vairport.ObtenerInformacion();
    }
    
    if (window.location.href.includes('listAdminAirport')) {
        vairport.RetrieveListAirportAdmin();
    }
});