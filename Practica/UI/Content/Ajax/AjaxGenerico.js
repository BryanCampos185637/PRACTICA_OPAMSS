var api = "http://localhost:60711/api/"

var api2 = 'http://localhost:4890/api/';

function PintarTabla(url, cabecera, propiedades, llavePrimaria, eliminar = true, editar = true) {
    let content = '';
    $.get(api + url, function (json) {
        content += '<table class="table table-bordered" id="tbAjaxContent">';
        //cabecera
        content += '<thead class="thead-dark">';
        content += '<tr>';
        for (let i = 0; i < cabecera.length; i++) {
            content += '<th>' + cabecera[i] + '</th>';
        }
        if (eliminar || editar)
            content += '<th class="text-center">OPCIONES</th>';
        content += '</tr>';
        content += '</thead>';
        //cuerpo tabla
        content += '<tbody>';
        if (json != null && json.length > 0) {//validamos que haya data en el json
            for (let i = 0; i < json.length; i++) {
                content += '<tr>';
                let FilaActual = json[i];
                for (let j = 0; j < propiedades.length; j++) {
                    let propiedadActual = propiedades[j];
                    content += '<td>';
                    content += FilaActual[propiedadActual];
                    content += '</td>';
                }
                if (eliminar || editar) {
                    content += '<td class="text-center">';
                    if (editar) {
                        content += '<button type="button" class="btn btn-sm btn-success" onclick="EditarRegistro(' + FilaActual[llavePrimaria] + ')">Editar</button>';
                    }
                    if (eliminar) {
                        content += "<button type='button' class='btn btn-sm btn-danger' onclick='EliminarRegistro(" + FilaActual[llavePrimaria] + ")'>Eliminar</button>";
                    }
                    content += '</td>';
                }
                content += '</tr>';
            }
        } else {//si no hay data
            let ncolumnas = cabecera.length + 1;
            content += '<tr class="text-center">'
            content += '<td colspan="' + ncolumnas + '">NO HAY REGISTROS</td>';
            content += '</tr>'
        }
        content += '</tbody>';
        content += '</table>';
        
        $('#tablaContenido').html(content);
        AgregarPaginado();
    });
}

function AgregarPaginado() {
    let tabla = $('#tbAjaxContent');
    if (tabla != undefined)
        $('#tbAjaxContent').DataTable({
            searching: false
        })
    else {
        MensajeError('No se pudo cargar la libreria DataTable')
    }
}

function MensajeExito(texto='Se guardo con exito') {
    Swal.fire({
        position: 'center',
        icon: 'success',
        title: texto,
        showConfirmButton: false,
        timer: 1500
    })
}

function MensajeError(texto = 'Error, intente mas tarde!') {
    Swal.fire({
        position: 'center',
        icon: 'error',
        title: texto,
        showConfirmButton: false,
        timer: 1500
    })
}

function MensajeConfirmacion(titulo = 'Eliminar!', texto ='¿Estas seguro que deseas eliminar el registro?',callback) {
    Swal.fire({
        title: titulo,
        text: texto,
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Si!',
        cancelButtonText:'Cancelar'
    }).then((result) => {
        if (result.isConfirmed) {
            callback();
        }
    })
}

function EliminarAjax(url,callback) {
    $.ajax({
        url: api + url,
        type: 'DELETE',
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        success: function (result) {
            if (result == 'ok')
                callback();
            else
                MensajeError();
        }
    })
}

function ValidarVacios(arreglo) {
    let rpt = true;
    for (let i = 0; i < arreglo.length; i++) {
        if (arreglo[i].value.trim() == '') {
            arreglo[i].style.borderColor = 'red'; rpt = false;
        } else {
            arreglo[i].style.borderColor = '#ccc';
        }
    }
    return rpt;
}

function LimpiarFormControl() {
    let arreglo = $('.form-control');
    for (let i = 0; i < arreglo.length; i++) {
        arreglo[i].style.borderColor = '#ccc';
        arreglo[i].value = '';
    }
}

function peticionGet(url,callback) {
    $.get(api + url, function (data) {
        callback(data);
    })
}

function llenarFormulario(json, arreglo) {
    for (let i = 0; i < arreglo.length; i++) {
        $('#' + arreglo[i].name).val(json[arreglo[i].name]);
    }
}

function EnviarInfo(url, tipo='POST', datos, callback) {
    $.ajax({
        url: api + url,
        type: tipo,
        processData: false,
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        data: JSON.stringify(datos),
        success: function (result) {
            callback(result);
        }
    })
}

function getText(id) {
    return document.getElementById(id).value;
}