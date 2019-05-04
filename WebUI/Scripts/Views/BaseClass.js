class BaseClass {
    /**
     * Constructor del Base class
     * @param {String} service Servicio al cual se hace consulta
     * @param {String} tbl Id de la tabla en la cual se desea mostrar datos
     * @param {String} form Id del formulario del cual se van a llenar o van a recuperar los datos
     */
    constructor(service, tbl, form) {
        this.ctrlActions = new ControlActions();
        this.service = service;
        this._tbl = tbl;
        this._form = form;
    }

    get form() {
        return this._form;
    }

    getForm (){
        let frm = document.querySelector(`#${this._form}`);
        return frm ? frm : this._form;
    };

    set form(value) {
        this._form = value;
    }

    get tbl() {
        return this._tbl;
    }

    /**
     * establece el nombre de la tabla
     */
    set tbl(tblName) {
        this._tbl = tblName;
    }

    /**
     * Crea un elemento en la base de datos
     */
    Create() {
        let data = {};
        data = this.ctrlActions.GetDataForm(this._form);
        //Hace el post al create
        this.ctrlActions.PostToAPI(this.service, data);
        //Refresca la tabla
        this.ReloadTable();
    }

    /**
     * Actualiza un elemento de la base de datos
     */
    Update() {

        let data = {};
        data = this.ctrlActions.GetDataForm(this._form);
        //Hace el post al create
        this.ctrlActions.PutToAPI(this.service, data);
        //Refresca la tabla
        this.ReloadTable();
    }

    /**
     * Borra un elemento de la base de datos
     */
    Delete() {
        let userData = {};
        userData = this.ctrlActions.GetDataForm(this._form);
        //Hace el post al create
        this.ctrlActions.DeleteToAPI(this.service, userData);
        //Refresca la tabla
        this.getForm().reset()
        this.ReloadTable();
    }

    /**
     * Llena los campos de un formulario con la informacion suministrada
     * @param {Json} data Informacion con la cual se va a llenar los campos del formulario
     */
    BindFields(data) {
        this.ctrlActions.BindFields(this._form, data);
    }

    /**
     * Puebla la tabla con la informacion recuperada del servicio
     */
    RetrieveAll() {
        this.ctrlActions.FillTable(this.service, this._tbl, false);
    }

    /**
     * Recarga la tabla que muesta los datos del servicio
     */
    ReloadTable() {
        this.ctrlActions.FillTable(this.service, this._tbl, true);
    }

    /**
     * Liga a el evento de llenar el formulario a la tabla
     * @param {Bolean} bind bandera que indica si la infoemacion seleccionada debe ir a un formulario
     */
    DataBind(bind) {
        let view = new BaseClass(this.service, this._tbl, this._form);
        let table = $(`#${this._tbl}`).DataTable();
        //el siguiente codigo agrega un eventoClic y se parametriza en OnSelect (evento)
        let tBody = $(`#${view._tbl} tbody`);
        tBody.off("click");
        if (bind) {
            tBody.on("click",
                "tr",
                function () {
                    const data = table.row(this).data();
                    sessionStorage.setItem(`${view._tbl}_selected`, data);
                    console.log(data);
                    view.BindFields(data);
                });
        }
    }
}