function validarPaquete() {
    const largo = document.getElementById("txtLargo").value.trim();
    const ancho = document.getElementById("txtAncho").value.trim();
    const alto = document.getElementById("txtAlto").value.trim();
    const peso = document.getElementById("txtPeso").value.trim();
    const cantidad = document.getElementById("txtCantidad").value.trim();
    const valor = document.getElementById("txtValor").value.trim();
    const mensaje = document.getElementById("lblMensajePaquete");

    if (!largo || !ancho || !alto || !peso || !cantidad || !valor) {
        mensaje.textContent = "Todos los campos son obligatorios.";
        mensaje.style.color = "red";
        return false;
    }

    if (isNaN(largo) || isNaN(ancho) || isNaN(alto) || isNaN(peso) || isNaN(cantidad) || isNaN(valor)) {
        mensaje.textContent = "Por favor, ingresá valores numéricos válidos.";
        mensaje.style.color = "red";
        return false;
    }

    if (parseFloat(largo) <= 0 || parseFloat(ancho) <= 0 || parseFloat(alto) <= 0 ||
        parseFloat(peso) <= 0 || parseInt(cantidad) <= 0 || parseFloat(valor) <= 0) {
        mensaje.textContent = "Los valores deben ser positivos.";
        mensaje.style.color = "red";
        return false;
    }

    return true;
}

function validarDestinatario() {
    const nombre = document.getElementById("txtNombreDestino").value.trim();
    const apellido = document.getElementById("txtApellidoDestino").value.trim();
    const telefono = document.getElementById("txtTelefonoDestino").value.trim();
    const email = document.getElementById("txtEmailDestino").value.trim();
    const cuil = document.getElementById("txtCUILDestino").value.trim();
    const calle = document.getElementById("txtCalleDestino").value.trim();
    const numero = document.getElementById("txtNumeroDestino").value.trim();
    const cp = document.getElementById("txtCPDestino").value.trim();
    const ciudad = document.getElementById("txtCiudadDestino").value.trim();
    const provincia = document.getElementById("txtProvinciaDesino").value.trim();
    const piso = document.getElementById("txtPisoDestino").value.trim();
    const mensaje = document.getElementById("lblMensajeError"); 

    mensaje.textContent = "";

    if (!nombre || !apellido || !telefono || !email || !cuil || !calle || !numero || !cp || !ciudad || !provincia) {
        mensaje.textContent = "Todos los campos obligatorios deben estar completos.";
        mensaje.style.color = "red";
        return false;
    }

    if (isNaN(cuil) || parseInt(cuil) <= 0) {
        mensaje.textContent = "El CUIL debe ser un número positivo.";
        mensaje.style.color = "red";
        return false;
    }

    if (isNaN(numero) || parseInt(numero) <= 0) {
        mensaje.textContent = "El número de calle debe ser un número positivo.";
        mensaje.style.color = "red";
        return false;
    }

    const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
    if (!emailRegex.test(email)) {
        mensaje.textContent = "El correo electrónico no tiene un formato válido.";
        mensaje.style.color = "red";
        return false;
    }

    if (telefono.length < 6) {
        mensaje.textContent = "El teléfono debe tener al menos 6 dígitos.";
        mensaje.style.color = "red";
        return false;
    }

    return true; 
}

