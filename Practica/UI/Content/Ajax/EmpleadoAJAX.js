window.onload = function () {
    ListarEmpleados();
    ListarCargos();
}

function ListarEmpleados() {
    let filtro = $('#txtFiltro').val();
    let url = 'Empleado?Filtro=';
    if (filtro != '') { url += filtro }
    PintarTabla(url, ['CARGO', 'EMPLEADO', 'EDAD', 'NACIMIENTO'],
        ['NombreCargo', 'NombreCompleto', 'Edad', 'FechaNacimiento'], 'EmpleadoId', true, true);
}

function EliminarRegistro(id) {
    MensajeConfirmacion(undefined, undefined, function () {
        EliminarAjax('Empleado/' + id, function () {
            ListarEmpleados();
            MensajeExito('Registro eliminado!')
        });
    });
};

function EditarRegistro(id) {
    peticionGet('DetalleEmpleado?id=' + id, function (json) {
        CambiarDOM('Editar');
        llenarFormulario(json, $('.data'));
    });
}

$('#frmRegistro').submit(function (e) {
    e.preventDefault();
    guardar();
})

function ListarCargos() {
    peticionGet('Cargo', function (json) {
        let content = '';
        content+='<option value="">--SELECCIONE UN CARGO--</option>'
        for (let i = 0; i < json.length; i++) {
            var filaActual = json[i];
            content += '<option value="' + filaActual['CargoId'] + '">' + filaActual['Nombre'] + '</option>'
        }
        $('#CargoId').html(content);
    });
}

function guardar() {
    if (ValidarVacios($('.r'))) {
        MensajeConfirmacion('Guardar', '¿Estas seguro que deseas guardar?', function () {
            var obj = {
                'EmpleadoId': $('#EmpleadoId').val(),
                'CargoId': $('#CargoId').val(),
                'Nombre': $('#Nombre').val(),
                'Apellido': $('#Apellido').val(),
                'Edad': $('#Edad').val(),
                'FechaNacimiento': $('#FechaNacimiento').val(),
                'Estado': 'ACT',
            }
            let tipo = 'POST';
            if ($('#EmpleadoId').val() != '' || $('#EmpleadoId').val() > 0) {
                tipo = 'PUT';
            }
            EnviarInfo('Empleado', tipo, obj, function (rpt) {
                if (rpt == 'Ok') {
                    ExitoEnvio();
                } else {
                    MensajeError(rpt);
                }
            });
        });
    } else {
        MensajeError('Debes completar los campos')
    }
}

function ExitoEnvio() {
    LimpiarFormControl();
    CambiarDOM('Mostrar Lista');
    MensajeExito('Se guardo correctamente');
    ListarEmpleados();
}

function CambiarDOM(opcion = null) {
    if (opcion == null)
        opcion = $('#btnOpciones').val();
    switch (opcion) {
        case 'Nuevo Empleado':
            LimpiarFormControl();
            $('#btnOpciones').val('Mostrar Lista');
            document.getElementById('tabla').style.display = 'none';
            document.getElementById('formulario').style.display = 'block';
            break;
        case 'Mostrar Lista':
            $('#btnOpciones').val('Nuevo Empleado');
            document.getElementById('tabla').style.display = 'block';
            document.getElementById('formulario').style.display = 'none';
            break;
        case 'Editar':
            LimpiarFormControl();
            $('#btnOpciones').val('Mostrar Lista');
            document.getElementById('tabla').style.display = 'none';
            document.getElementById('formulario').style.display = 'block';
            break;
    }
}