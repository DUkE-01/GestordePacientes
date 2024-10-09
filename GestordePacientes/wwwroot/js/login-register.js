document.addEventListener('DOMContentLoaded', function () {
    // Selección de elementos comunes
    const errorLogin = document.getElementById("error-message-login");
    const errorRegister = document.getElementById("error-message-register");

    // Función para validar el formulario de registro
    function validarFormularioRegistro() {
        const nombre = document.getElementsByName('nombre')[0];
        const apellido = document.getElementsByName('apellido')[0];
        const nombredeususario = document.getElementsByName('nombredeususario')[0];
        const consultorio = document.getElementsByName('consultorio')[0];
        const correo = document.getElementsByName('correo')[0];
        const contrasena = document.getElementsByName('contrasena')[0];
        const confirmarcontrasena = document.getElementsByName('confirmarcontrasena')[0];
        const rol = document.querySelector('.form-select'); // Selección del select de rol
        let messages = [];

        // Validaciones de los campos del formulario de registro
        if (nombre.value === '' || nombre.value == null) {
            messages.push("Ingresa tu nombre");
        }

        if (apellido.value === '' || apellido.value == null) {
            messages.push("Ingresa tu apellido");
        }

        if (nombredeususario.value === '' || nombredeususario.value == null) {
            messages.push("Ingresa tu nombre de usuario");
        }

        if (consultorio.value === '' || consultorio.value == null) {
            messages.push("Ingresa tu consultorio");
        }

        if (correo.value === '' || correo.value == null) {
            messages.push("Ingresa tu correo electrónico");
        }

        if (contrasena.value === '' || contrasena.value == null) {
            messages.push("Ingresa tu contraseña");
        }

        if (confirmarcontrasena.value !== contrasena.value) {
            messages.push("Las contraseñas no coinciden");
        }

        if (rol.value === 'Selecciona:' || rol.value == null) {
            messages.push("Selecciona un rol");
        }

        if (messages.length > 0) {
            errorRegister.textContent = messages.join(', ');
            errorRegister.style.display = "block";
            return false; // Detener el envío del formulario si hay errores
        } else {
            errorRegister.style.display = "none";
            return true; // El formulario es válido
        }
    }

    // Función para validar el formulario de login
    function validarFormularioLogin() {
        const correo = document.getElementById('email');
        const contraseña = document.getElementById('password');
        let messages = [];

        // Validaciones del formulario de login
        if (correo.value === '' || correo.value == null) {
            messages.push("Ingresa tu dirección de correo electrónico");
        }

        if (contraseña.value === '' || contraseña.value == null) {
            messages.push("Ingresa tu contraseña");
        }

        if (messages.length > 0) {
            errorLogin.textContent = messages.join(', ');
            errorLogin.style.display = "block";
            return false; // Hay errores, detener el envío del formulario
        } else {
            errorLogin.style.display = "none";
            return true; // El formulario es válido
        }
    }

    // Manejo de envío del formulario de registro
    const formRegistro = document.getElementById('formulario__register');
    if (formRegistro) {
        formRegistro.addEventListener('submit', function (e) {
            e.preventDefault(); // Evitar el envío del formulario por defecto

            if (validarFormularioRegistro()) {
                $.ajax({
                    type: 'POST',
                    url: formRegistro.getAttribute('action'),
                    data: $(formRegistro).serialize(),
                    success: function (response) {
                        response = JSON.parse(response);
                        if (response.success) {
                            Swal.fire({
                                title: "¡Registro exitoso!",
                                text: "¡Tu cuenta ha sido creada correctamente!",
                                icon: "success"
                            });
                            // Redirigir a otra página si es necesario
                        } else {
                            Swal.fire({
                                title: "Error en el registro",
                                text: response.message,
                                icon: "error"
                            });
                        }
                    },
                    error: function () {
                        Swal.fire({
                            title: "Error",
                            text: "Ha ocurrido un error. Inténtalo de nuevo más tarde.",
                            icon: "error"
                        });
                    }
                });
            }
        });
    }

    // Manejo de envío del formulario de login
    const formLogin = document.getElementById('formulario__login');
    if (formLogin) {
        formLogin.addEventListener('submit', function (e) {
            e.preventDefault(); // Evitar el envío del formulario por defecto

            if (validarFormularioLogin()) {
                $.ajax({
                    type: 'POST',
                    url: formLogin.getAttribute('action'),
                    data: $(formLogin).serialize(),
                    success: function (response) {
                        response = JSON.parse(response);
                        if (response.success) {
                            Swal.fire({
                                title: "¡Contraseña correcta!",
                                text: "¡Se ha iniciado sesión correctamente!",
                                icon: "success"
                            });
                            // Redirigir a otra página si es necesario
                        } else {
                            Swal.fire({
                                title: "Contraseña y/o usuario incorrectos. Intenta nuevamente.",
                                text: response.message,
                                icon: "error"
                            });
                        }
                    },
                    error: function () {
                        Swal.fire({
                            title: "Error",
                            text: "Ha ocurrido un error. Inténtalo de nuevo más tarde.",
                            icon: "error"
                        });
                    }
                });
            }
        });
    }
});
