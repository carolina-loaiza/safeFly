'use strict';

function vFlight() {

    this.tblFlightId = "tblFlights";
    this.service = "flight";
    this.ctrlActions = new ControlActions();
    this.columns = "FlyNumber,SeatsQuantify,FirstClassSeats,BusinessClassSeats,EconomicClassSeats,Status";

    const inputFirstClassSeats = document.querySelector('#txtFirstClassSeats');
    const inputBusinessClassSeats = document.querySelector('#txtBusinessClassSeats');
    const inputEconomicClassSeats = document.querySelector('#txtEconomicClassSeats');
    const inputSeatsQuantify = document.querySelector('#txtSeatsQuantify');
    const comboStatus = document.querySelector('#cmbStatus');

    const regexSoloLetras = /^[a-z A-Z-áéíóúÁÉÍÓÚñÑ0-9]+$/;
    const regexSoloNumeros = /^[0-9]+$/;
    const regexCodigo = /^[a-zA-Z0-9-]+$/;

    this.RetrieveAll = function () {
        this.ctrlActions.FillTable(this.service, this.tblFlightId, false);
    }

    this.ReloadTable = function () {
        this.ctrlActions.FillTable(this.service, this.tblFlightId, true);
    }

    this.Create = function () {
        let sumaAsientos = 0;
        let nFirstClassSeats = Number(inputFirstClassSeats.value);
        let nBusinessClassSeats = Number(inputBusinessClassSeats.value);
        let nEconomicClassSeats = Number(inputEconomicClassSeats.value);
        let numeroVuelo = 0;

        numeroVuelo = Math.floor(Math.random() * (100000 - 1)) + 1;

        document.getElementById('txtFlyNumber').value = numeroVuelo;


        sumaAsientos = nFirstClassSeats + nBusinessClassSeats + nEconomicClassSeats;
        let totalAsientos = Number(inputSeatsQuantify.value);

        var flightData = {};
        flightData = this.ctrlActions.GetDataForm('frmEdition');
        //Hace el post al create
        if (sumaAsientos <= totalAsientos && this.ValidateInfo() != true) {
            this.ctrlActions.PostToAPI(this.service, flightData);
        }
        this.LimpiarFormulario();
        //Refresca la tabla
        this.ReloadTable();
    }

    this.Update = function () {
        let sumaAsientos = 0;

        let nFirstClassSeats = Number(inputFirstClassSeats.value);
        let nBusinessClassSeats = Number(inputBusinessClassSeats.value);
        let nEconomicClassSeats = Number(inputEconomicClassSeats.value);
        let totalAsientos = Number(inputSeatsQuantify.value);
        let sStatus = comboStatus.value;

        numeroVuelo = Math.floor(Math.random() * (100000 - 1)) + 1;
        sumaAsientos = nFirstClassSeats + nBusinessClassSeats + nEconomicClassSeats;

        document.getElementById('txtStatus').value = sStatus;


        var flightData = {};
        flightData = this.ctrlActions.GetDataForm('frmEdition');
        //Hace el post al create
        if (sumaAsientos <= totalAsientos && this.ValidateInfo() != true) {
            this.ctrlActions.PutToAPI(this.service, flightData);
        }
        this.LimpiarFormulario();
        //Refresca la tabla
        this.ReloadTable();
    }

    this.Delete = function () {

        var flightData = {};
        flightData = this.ctrlActions.GetDataForm('frmEdition');
        //Hace el post al create
        this.ctrlActions.DeleteToAPI(this.service, flightData);
        Swal.fire({
            title: 'Desactivación correcta',
            text: 'El vuelo se desactivo correctamente',
            type: 'sucess',
            confirmButtonText: 'Ok'
        });
        //Refresca la tabla
        this.ReloadTable();

    }

    this.BindFields = function (data) {
        this.ctrlActions.BindFields('frmEdition', data);
        $("#txtFlyNumber").prop("disabled", true); //Disable
    }

    this.ValidateInfo = function () {
        let error = false;
        if (regexSoloNumeros.test(inputSeatsQuantify.value) == false) {
            error = true;
            inputSeatsQuantify.classList.add('is-invalid');
        } else {
            inputSeatsQuantify.classList.remove('is-invalid');
        }

        if (regexSoloNumeros.test(inputFirstClassSeats.value) == false && inputFirstClassSeats.value <= inputSeatsQuantify.value) {
            error = true;
            inputSeatsQuantify.classList.add('is-invalid');
        } else {
            inputSeatsQuantify.classList.remove('is-invalid');
        }

        if (regexSoloNumeros.test(inputBusinessClassSeats.value) == false && inputBusinessClassSeats.value <= inputSeatsQuantify.value) {
            error = true;
            inputSeatsQuantify.classList.add('is-invalid');
        } else {
            inputSeatsQuantify.classList.remove('is-invalid');
        }

        if (regexSoloNumeros.test(inputBusinessClassSeats.value) == false && inputBusinessClassSeats.value <= inputSeatsQuantify.value) {
            error = true;
            inputSeatsQuantify.classList.add('is-invalid');
        } else {
            inputSeatsQuantify.classList.remove('is-invalid');
        }
        return error;
    }

    this.LimpiarFormulario = function () {
        inputSeatsQuantify.value = '';
        inputFirstClassSeats.value = '';
        inputBusinessClassSeats.value = '';
        inputEconomicClassSeats.value = '';
    }
}

//ON DOCUMENT READY
$(document).ready(function () {

    var vflight = new vFlight();
    vflight.RetrieveAll();

});