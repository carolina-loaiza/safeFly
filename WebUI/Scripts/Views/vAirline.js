function vAirline() {
    this.tblAirlineId = 'tblAirlines';
    this.service = 'airline';
    this.serviceUser = 'user';
    this.serviceAirport = "airport";
    this.serviceSolicitude = "airlinexairport";
    this.newAirlineID = '';
    this.ctrlActions = new ControlActions();
    this.airportList = [];
    this.modifyData = {};
    this.columns = "ID,Name,BusinessName,Admin,Email,PhoneNumber,RepresentantLegal,InscriptionDate,Status";
    sessionStorage.setItem('view', 'vAirline');
     var userLogin = JSON.parse(sessionStorage.getItem("user"));
     var CtrlActions = new ControlActions();
     
    this.RetrieveAll = function () {
        if (userLogin.RolName == 'AdminAeropuerto') {
            $.get(this.ctrlActions.GetUrlApiService('Airport/ByAdminID/'+userLogin.ID), function (response) {     
                CtrlActions.FillTable('Airline/AllApproval/'+response.Data.LegalNumber+'/Activo', 'tblAirlines', false, false); 
            })
        } else {
             this.ctrlActions.FillTable(this.service, this.tblAirlineId, false, false);
        }
    }
    
    this.ModifyAirline = function () {
        var airlineData = {};
        var CtrlActions = this.ctrlActions;
        var airlineDataModify = JSON.parse(sessionStorage.getItem("airlineDataModify"));
        airlineData = this.ctrlActions.GetDataForm('formModifyAirline');
        
        airlineData.InscriptionDate = airlineDataModify.InscriptionDate;
        airlineData.Approvement = airlineDataModify.Approvement;
        airlineData.Status = airlineDataModify.Status;
        airlineData.UrlLogo = 'null';
        
        $.put(this.ctrlActions.GetUrlApiService(this.service), airlineData, function (response) {            
            Swal.fire({
                title: 'Complete',
                text: 'The airline updated correctly.',
               type: 'success',
                confirmButtonText: 'OK'
            }).then((result) => {
                 if (userLogin.RolName == 'AdminAerolinea') {
                    window.location.reload();
                 }
              })     
        })
        .fail(function (response) {
             var data = response.responseJSON;
             Swal.fire({
                    title: 'An error has occurred',
                    text: 'Please check the information and submit again.',
                   type: 'error',
                    confirmButtonText: 'OK'
               });
         })
    }
    
    this.CreateUser = function () {
        var userData = {};
        var CtrlActions = this.ctrlActions;
        userData = this.ctrlActions.GetDataForm('frmEdition');
        if (!userData) {
            return false;
        }
        $.post(this.ctrlActions.GetUrlApiService(this.serviceUser), userData, function (response) {            
             CtrlActions.PostToAPI("userxrolexview", {
                "UserId": userData.ID,
                "RoleId": 6,
                "ViewId": 3
             });
             $('#collapseOne').collapse({
                  toggle: false
              });
              $('#collapseTwo').collapse({
                  toggle: true
              })
              $("#collapseOne-button").attr("disabled", true)
              $("#collapseTwo-button").attr("disabled", false)
        })
        .fail(function (response) {
             var data = response.responseJSON;
             Swal.fire({
                    title: 'An error has occurred',
                    text: 'Please check the information and try again.',
                   type: 'error',
                    confirmButtonText: 'OK'
               });
         })
    }

    this.CreateAirline = function () {
        var airlineData  = this.ctrlActions.GetDataForm('formAirline');
        if (!airlineData) {
            return false;
        }
        airlineData.ID = (Math.floor(Math.random() * 10000) + 1000000) + "";
        airlineData.InscriptionDate = new Date().toJSON().slice(0,10).replace(/-/g,'/');
        airlineData.Approvement = "Inactivo";
        airlineData.Status = "Inactivo";
        sessionStorage.setItem("newAirlineID", airlineData.ID);
        $.post(this.ctrlActions.GetUrlApiService(this.service), airlineData, function (response) {            
              $("#collapseTwo-button").attr("disabled", true)
              $("#collapseThree-button").attr("disabled", false)
              
             $('#collapseTwo').collapse({
                  toggle: false
              });
              $('#collapseThree').collapse({
                  toggle: true
              })
        })
        .fail(function (response) {
             var data = response.responseJSON;
               Swal.fire({
                    title: 'An error has occurred',
                    text: 'Please check the information and try again.',
                   type: 'error',
                    confirmButtonText: 'OK'
               });
         })
    }

    this.BindFields = function (data) {
        this.modifyData = data;
        $('#airlineName').text(this.modifyData.Name);
        this.ctrlActions.BindFields('formModifyAirline', data);
    }
    
   this.ObtenerInformacion = function () {
        if (userLogin.RolName == 'AdminAerolinea') {
            var ctrlActions =  this.ctrlActions;
           $.get(this.ctrlActions.GetUrlApiService('Airline/ByAdminID/'+userLogin.ID), function (response) {            
                ctrlActions.BindFields('formModifyAirline', response.Data);
                sessionStorage.setItem('airlineDataModify', JSON.stringify(response.Data));
            })
            $("#formModifyAirline input[name=txtAdmin]").attr("disabled", true)
        }
    }

    this.getAirportList = function () {
        $.get(this.ctrlActions.GetUrlApiService(this.serviceAirport), function (response) {
            this.airportList = response.Data;

            this.airportList.forEach(function (element) {
                var item = '<div class="col-md-6">' +
                    '<div class="form-check">' +
                    '<input type="checkbox" id="check-' + element.LegalNumber + '" class="form-check-input" value="' + element.LegalNumber + '">' +
                    '<label for="check-' + element.LegalNumber + '" class="form-check-label">' + element.NameAirport + '</label>' +
                    '</div>' +
                    '</div>'

                $('#airportListContainer').append(item);
            });

        })
    }

    this.CreateSolicitude = function () {
        var data = $('.form-check-input:checkbox:checked');
        var thisAirline = this;
        
        $.each(data, function (key, element) {
            var newSolicitude = {
                AirlineID: sessionStorage.getItem("newAirlineID"),
                AirportID: element.value,
                InscriptionFee: 1.1,
                Status: "Inactivo"
            }
            thisAirline.ctrlActions.PostToAPI(thisAirline.serviceSolicitude, newSolicitude);
        })
        
       Swal.fire({
          title: 'Done!',
          text: 'The application was send to the airports administrator for approval. We will send you an email with the confirmation.',
          type: 'sucess',
          confirmButtonColor: '#3085d6',
          confirmButtonText: 'Ok'
        }).then((result) => {
              window.location.href = '/';
        })
    }
}


$(document).ready(function () {

    var vairline = new vAirline();
    var listTable = $('#' + vairline.tblAirlineId).length;
    if (listTable) {
        vairline.RetrieveAll();
    } else {
        $("#formAirline input[name=txtAdmin]").attr("disabled", true)
        $("#formModifyAirline input[name=txtID]").attr("disabled", true)

        $('#frmEdition input[name=txtID]').keyup(function () {
            var value = $(this).val();
            $("#formAirline input[name=txtAdmin]").val(value);
        });
        
        vairline.getAirportList();
    }
    
    if (window.location.href.includes('modifyAirline')) {
        vairline.ObtenerInformacion();
    }
});