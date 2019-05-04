class VTax extends BaseClass {
    Create() {
        const data = this.ctrlActions.GetDataForm(this._form);
        data.status = "active";
        this.ctrlActions.PostToAPI(this.service, data);
        this.ReloadTable();
        document.querySelector(`#${this._form}`).reset();
    }

    Update() {

        let data = {};
        data = this.ctrlActions.GetDataForm(this._form);
        let status = document.querySelector("#Status");
        if (status) data.Status = status.checked;
        //Hace el post al create
        this.ctrlActions.PutToAPI(this.service, data);
        this.getForm().reset();
        //Refresca la tabla
        let fun=()=>this.ReloadTable();
        setTimeout(function () {
            fun();
        }, 1000)

    }

    constructor() {
        super("tax", "tblTax", "frmTax");
    }
}