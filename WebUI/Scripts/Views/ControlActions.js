function ControlActions() {

    this.URL_API = "http://localhost:55614/api/";  //WebAPI

    this.GetUrlApiService = function (service) {
        return this.URL_API + service;
    }

    this.GetTableColumsDataName = function (tableId) {
        var val = $('#' + tableId).attr("ColumnsDataName");

        return val;
    }

    this.FillTable = function (service, tableId, refresh) {

        if (!refresh) {
            columns = this.GetTableColumsDataName(tableId).split(',');
            var arrayColumnsData = [];


            $.each(columns, function (index, value) {
                var obj = {};
                obj.data = value;
                arrayColumnsData.push(obj);
            });

            $('#' + tableId).DataTable({
                "processing": true,
                "ajax": {
                    "url": this.GetUrlApiService(service),
                    dataSrc: function (json) {
                        for (var i = 0; i < json.Data.length; i++) {
                            $.each(json.Data[i], function (key, value) {
                                if (typeof value === 'string' && value.indexOf("T00:00:00") !== -1) {
                                    json.Data[i][key] = value.substring(0, value.indexOf('T'));
                                }
                            });
                        }
                        return json.Data;
                    }
                },
                "columns": arrayColumnsData
            });
        } else {
            //RECARGA LA TABLA
            $('#' + tableId).DataTable().ajax.reload();
        }

    }

    this.GetSelectedRow = function () {
        var data = sessionStorage.getItem(tableId + '_selected');

        return data;
    };

    this.BindFields = function (formId, data) {
        console.log(data);
        $('#' + formId + ' *').filter(':input').each(function (input) {
            var columnDataName = $(this).attr("ColumnDataName");
            if (data[columnDataName] && data[columnDataName].indexOf("T00:00:00") !== -1) {
                this.value = data[columnDataName].substring(0, data[columnDataName].indexOf('T'));
            } else {
                this.value = data[columnDataName];
            }
        });
    }

    this.GetDataForm = function (formId) {
        var data = {};

        $('#' + formId + ' *').filter(':input').each(function (input) {
            var columnDataName = $(this).attr("ColumnDataName");
            data[columnDataName] = this.value;
        });
        let valid=true;
        let fun=(str,matches)=>{for (let i=0;i<matches.length;i++){
            if (str.toLowerCase().includes(matches[i])){
                return true;
            }
        }};
        let frm=document.querySelector(`#${formId}`);
        for (let key in data) {
            if (fun(key, ['id', 'mail', 'name']) && data[key] === '') {
                console.log(`${key} is empty`);
                valid = false;
                frm.querySelector(`[ColumnDataName=${key}]`).classList.add('is-invalid');
            } else {
                if (fun(key,['mail'])) {
                    let re = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
                    valid= re.test(data[key].toLowerCase());
                }
            }
        }

        console.log(data);
        if (valid){
            return data;
        }
    };

    this.ShowMessage = function (type, message) {
        if (type == 'E') {
            $("#alert_container").removeClass("alert alert-success alert-dismissable")
            $("#alert_container").addClass("alert alert-danger alert-dismissable");
            $("#alert_message").text(message);
        } else if (type == 'I') {
            $("#alert_container").removeClass("alert alert-danger alert-dismissable")
            $("#alert_container").addClass("alert alert-success alert-dismissable");
            $("#alert_message").text(message);
        }
        $('.alert').show();
    };

    this.PostToAPI = function (service, data) {

        var jqxhr = $.post(this.GetUrlApiService(service), data, function (response) {
            var ctrlActions = new ControlActions();
            ctrlActions.ShowMessage('I', response.Message);
        })
            .fail(function (response) {
                var data = response.responseJSON;
                var ctrlActions = new ControlActions();
                ctrlActions.ShowMessage('E', data.ExceptionMessage);
                console.log(data);
            })
    };

    this.PutToAPI = function (service, data) {
        var jqxhr = $.put(this.GetUrlApiService(service), data, function (response) {
            var ctrlActions = new ControlActions();
            ctrlActions.ShowMessage('I', response.Message);
        })
            .fail(function (response) {
                var data = response.responseJSON;
                var ctrlActions = new ControlActions();
                ctrlActions.ShowMessage('E', data.ExceptionMessage);
                console.log(data);
            })
	};

    this.DeleteToAPI = function (service, data) {
        var jqxhr = $.delete(this.GetUrlApiService(service), data, function (response) {
            var ctrlActions = new ControlActions();
            ctrlActions.ShowMessage('I', response.Message);
        })
            .fail(function (response) {
                var data = response.responseJSON;
                var ctrlActions = new ControlActions();
                ctrlActions.ShowMessage('E', data.ExceptionMessage);
                console.log(data);
            })
    };

    this.ActivarToAPI = function (service, data) {
        var jqxhr = $.activar(this.GetUrlApiService(service), data, function (response) {
        
      //  var jqxhr = $.put(this.GetUrlApiService(service), data, function (response) {
            var ctrlActions = new ControlActions();
            ctrlActions.ShowMessage('I', response.Message);
        })
            .fail(function (response) {
                var data = response.responseJSON;
                var ctrlActions = new ControlActions();
                ctrlActions.ShowMessage('E', data.ExceptionMessage);
                console.log(data);
            })
    };

    this.LogInToAPI = function (service, data) {

        var array = [];
        for (var prop in data) {
            array.push(data[prop]);
        }
        var email = array[0];
        var password = array[1];
        var jqxhr = $.login(this.GetUrlApiService(service), email, password, function (response) {
            var ctrlActions = new ControlActions();
            ctrlActions.ShowMessage('I', response.Message);
            var log = new vLogIn();
            log.ValidateCredentials(array,true);
        })
            .fail(function (response) {
                var data = response.responseJSON;
                var ctrlActions = new ControlActions();
                ctrlActions.ShowMessage('E', data.ExceptionMessage);
                var log = new vLogIn();
                log.ValidateCredentials(array, false);
            })
	};

    this.EmailToAPI = function (service, data) {

        var array = [];
        for (var prop in data) {
            array.push(data[prop]);
        }
        var email = array[0];
        var jqxhr = $.email(this.GetUrlApiService(service), email, function (response) {
            var ctrlActions = new ControlActions();
            ctrlActions.ShowMessage('I', response.Message);
            var log = new vLogIn();
            log.UserSession(response);
        })
            .fail(function (response) {
                var data = response.responseJSON;
                var ctrlActions = new ControlActions();
                ctrlActions.ShowMessage('E', data.ExceptionMessage);
            })
    };

	this.GetToApi = function (service, callbackFunction) {
		var jqxhr = $.get(this.GetUrlApiService(service), function (response) {
			console.log("Response " + response);
			callbackFunction(response.Data);
		});
	}

    this.GetToSelect = function (service, callback) {
        var array = []

        var jqxhr = $.get(this.GetUrlApiService(service), function (response) {
            var ctrlActions = new ControlActions();
            ctrlActions.ShowMessage('I', response.Message);
            var info = [];
            for (var prop in response) {
                info.push(response[prop]);
            }
            callback(info, true);
        })
            .fail(function (response) {
                var data = response.responseJSON;
                var ctrlActions = new ControlActions();
                ctrlActions.ShowMessage('E', data.ExceptionMessage);

                callback([], false);
            })
    };
};

//Custom jquery actions
$.login = function (url, email, password, callback) {
    if ($.isFunction(email, password)) {
        type = type || callback,
            callback = email + password,
            data = {
                'email': email,
                'password': password
            }
    }
    return $.ajax({
        url: url,
        type: 'GET',
        success: callback,
        data: {
            'email': email,
            'password': password
        },
        contentType: 'application/json'
    });
}

$.put = function (url, data, callback) {
    if ($.isFunction(data)) {
        type = type || callback,
            callback = data,
            data = {}
    }
    return $.ajax({
        url: url,
        type: 'PUT',
        success: callback,
        data: JSON.stringify(data),
        contentType: 'application/json'
    });
}

$.activar = function (url, data, callback) {
    if ($.isFunction(data)) {
        type = type || callback,
            callback = data,
            data = {}
    }
    return $.ajax({
        url: url,
        type: 'PUT',
        success: callback,
        data: JSON.stringify(data),
        contentType: 'application/json'
    });
}

$.delete = function (url, data, callback) {
    if ($.isFunction(data)) {
        type = type || callback,
            callback = data,
            data = {}
    }
    return $.ajax({
        url: url,
        type: 'DELETE',
        success: callback,
        data: JSON.stringify(data),
        contentType: 'application/json'
    });
}


$.email = function (url, email, callback) {
    if ($.isFunction(email)) {
        type = type || callback,
            callback = email,
            data = {
                'email': email
            }
    }
    return $.ajax({
        url: url,
        type: 'GET',
        success: callback,
        data: {
            'email': email
        },
        contentType: 'application/json'
    });
}



$.sendemail = function (url, data, callback) {
	if ($.isFunction(data)) {
		type = type || callback,
			callback = data,
			data = {}
	}
	return $.ajax({
		url: url,
		type: 'GET',
		success: callback,
		data: {
			'email': data
		},
		contentType: 'application/json'
	});
}

//$.get = function (url, callback) {
//    if ($.isFunction(data)) {
//        type = type || callback,
//            callback = data,
//            data = {}
//    }
//    return $.ajax({
//        url: url,
//        type: 'Get',
//        success: callback,
//        data: JSON.stringify(data),
//        contentType: 'application/json'
//    });
//}