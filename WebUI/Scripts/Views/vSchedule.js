'use strict';

function vSchedule() {

    this.tblScheduleId = "tblSchedules";
    this.service = "schedule";
    this.ctrlActions = new ControlActions();
    this.columns = "Id,FlyNumber,Aproovement,Gate,Destiny,Departure,DepartureDate,ArriveDate";

    this.SetInformation = function () {
        window.location.href = '/Dashboard/createSchedule';
    }

    this.RetrieveAll = function () {
        this.ctrlActions.FillTable(this.service, this.tblScheduleId, false);
    }

    this.ReloadTable = function () {
        this.ctrlActions.FillTable(this.service, this.tblScheduleId, true);
    }

    this.Create = function () {
        var scheduleData = {};
        scheduleData = this.ctrlActions.GetDataForm('frmEdition');
        //Hace el post al create
        this.ctrlActions.PostToAPI(this.service, scheduleData);
        //Refresca la tabla
        this.ReloadTable();
    }

    this.Update = function () {

        var scheduleData = {};
        scheduleData = this.ctrlActions.GetDataForm('frmEdition');
        //Hace el post al create
        this.ctrlActions.PutToAPI(this.service, scheduleData);
        //Refresca la tabla
        this.ReloadTable();

    }

    this.Delete = function () {

        var scheduleData = {};
        scheduleData = this.ctrlActions.GetDataForm('frmEdition');
        //Hace el post al create
        this.ctrlActions.DeleteToAPI(this.service, scheduleData);
        Swal.fire({
            title: 'Desactivación correcta',
            text: 'El horario se desactivo correctamente',
            type: 'sucess',
            confirmButtonText: 'Entendido'
        });
        //Refresca la tabla
        this.ReloadTable();

    }

    this.BindFields = function (data) {
        this.ctrlActions.BindFields('frmEdition', data);
        sessionStorage.setItem('scheduleData', JSON.stringify(data));
    }
}

//ON DOCUMENT READY
$(document).ready(function () {

    var vschedule = new vSchedule();
    vschedule.RetrieveAll();
});