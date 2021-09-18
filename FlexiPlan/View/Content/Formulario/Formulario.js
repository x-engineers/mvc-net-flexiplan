$(document).ready(function () {

    $(document).ready(function () {

        var current_fs, next_fs, previous_fs; //fieldsets
        var opacity;
        var current = 1;
        var steps = $("fieldset").length;
        var enviar = false;
        setProgressBar(current);

        $(".next").click(function () {

            $('#msform').formValidation('validate');

            if ($('#msform').data('formValidation').validate().isValid()) {
                current_fs = $(this).parent();
                next_fs = $(this).parent().next();
                //Add Class Active
                $("#progressbar li").eq($("fieldset").index(next_fs)).addClass("active");

                //show the next fieldset
                next_fs.show();
                //hide the current fieldset with style
                current_fs.animate({ opacity: 0 }, {
                    step: function (now) {
                        // for making fielset appear animation
                        opacity = 1 - now;

                        current_fs.css({
                            'display': 'none',
                            'position': 'relative'
                        });
                        next_fs.css({ 'opacity': opacity });
                    },
                    duration: 500
                });
                setProgressBar(++current);
            }

        });

        $(".previous").click(function () {

            $('#msform').formValidation('validate');
            if ($('#msform').data('formValidation').validate().isValid()) {
                current_fs = $(this).parent();
                previous_fs = $(this).parent().prev();

                //Remove class active
                $("#progressbar li").eq($("fieldset").index(current_fs)).removeClass("active");

                //show the previous fieldset
                previous_fs.show();

                //hide the current fieldset with style
                current_fs.animate({ opacity: 0 }, {
                    step: function (now) {
                        // for making fielset appear animation
                        opacity = 1 - now;

                        current_fs.css({
                            'display': 'none',
                            'position': 'relative'
                        });
                        previous_fs.css({ 'opacity': opacity });
                    },
                    duration: 500
                });
                setProgressBar(--current);
            }
        });

        function setProgressBar(curStep) {
            var percent = parseFloat(100 / steps) * curStep;
            percent = percent.toFixed();
            $(".progress-bar")
                .css("width", percent + "%")
        }

        $("#btnEnviar").click(function () {

            enviar = true;
            $('#msform').formValidation('validate');
        })

        if (history.forward(1)) {
            location.replace(history.forward(1));
        }

        //EVENTOS ++++++++++++++++++++++++++++++++++++++++++++++++++++
        $("#ckb_acepto").change(function () {
            if ($('input:checkbox[id=ckb_acepto]').prop('checked') == false) {
                $("#btnEnviar").css({ 'background-color': '#9B9B9B', 'border-color': '#9B9B9B' });
                $("#btnEnviar").prop('disabled', true);
                $(".checkboxWrapper").css({ 'background-color': '#757575' });
            }
            else {
                $("#btnEnviar").css({ 'background-color': '#057bb8', 'border-color': '#AD0000' });
                $("#btnEnviar").prop('disabled', false);
                $(".checkboxWrapper").css({ 'background-color': '#057bb8' });
            }
        });

        $("#btnEnviar").css({ 'background-color': '#9B9B9B', 'border-color': '#9B9B9B' });
        $("#btnEnviar").prop('disabled', true);
        $(".checkboxWrapper").css({ 'background-color': '#757575' });
        $(".DUI").inputmask("99999999-9", { placeholder: " ", clearMaskOnLostFocus: true });
        $(".NIT").inputmask("9999-999999-999-9", { placeholder: " ", clearMaskOnLostFocus: true });
        $(".telefono").inputmask("9999-9999", { placeholder: " ", clearMaskOnLostFocus: true });

        //VALIDACIONES DEL FORMULARIO
        $('#msform').formValidation({
            icon: {
                valid: 'glyphicon glyphicon-ok',
                invalid: 'glyphicon glyphicon-remove',
                validating: 'glyphicon glyphicon-refresh'
            },
            fields: {
                BuroNombres: {
                    validators: {
                        notEmpty: {
                            message: 'Nombre requerido'
                        }
                    }
                },
                BuroApellidos: {
                    validators: {
                        notEmpty: {
                            message: 'Apellido requerido'
                        }
                    }
                },
                BuroDUI: {
                    validators: {
                        notEmpty: {
                            message: 'DUI requerido'
                        },
                        callback: {
                            callback: function (value, validator) {
                                if (value.length > 0)
                                    if (!ValidarFormatoDUI(value)) {
                                        return {
                                            valid: false,
                                            message: 'DUI no válido'
                                        }
                                    }
                                return true;
                            }
                        }
                    }
                },
                BuroNIT: {
                    validators: {
                        notEmpty: {
                            message: 'NIT requerido'
                        },
                        callback: {
                            callback: function (value, validator) {
                                var valorActual = value.replace(/-/g, "").trim();
                                if (value.length > 0)
                                    if (valorActual.length < 14 || valorActual.length > 14) {
                                        return {
                                            valid: false,
                                            message: 'NIT no válido'
                                        }
                                    }
                                return true;
                            }
                        }
                    }
                },
                BuroTelefono: {
                    validators: {
                        callback: {
                            callback: function (value, validator) {
                                if (value.length > 1)
                                    if (value.substring(0, 1) != "2" && value.substring(0, 1) != "6" && value.substring(0, 1) != "7") {
                                        return {
                                            valid: false,
                                            message: 'El teléfono no es válido'
                                        }
                                    }
                                return true;
                            }
                        },
                        regexp: {
                            regexp: /^\(?([0-9]{4})[-]?([0-9]{4})$/,
                            message: 'El teléfono no es válido'
                        }
                    }
                },
                BuroCorreo: {
                    validators: {
                        emailAddress: {
                            message: 'El correo no es válido'
                        }
                    }
                }
            }
        })
            //<<<<<FormValidation - Inicio de eventos de validacion>>>>>>>>>>
            .on('success.field.fv', function (e, data) {
                var $parent = data.element.parents('.form-group');
                $parent.removeClass('has-success');
                data.element.data('fv.icon').hide();
            })
            .on('success.form.fv', function (e) {
                e.preventDefault();
                var $form = $(e.target);
                var bv = $form.data('formValidation');

                if (enviar) {
                    $.ajax({ url: $form.attr('action'), type: "POST", data: $form.serialize() })
                        .done(function (data, textStatus, jqXHR) {
                            window.close();
                            window.location.href = "https://www.facebook.com/FlexiPlanElSalvador/";
                        });
                }

            });


        //Validacion de DUI 
        function ValidarFormatoDUI(numero) {
            var regex = /(^\d{8})-(\d$)/, parts = numero.match(regex);
            // verficar formato y extraer digitos junto al digito verificador
            if (parts !== null) {
                var digits = parts[1], dig_ve = parseInt(parts[2], 10), sum = 0;
                // sumar producto de posiciones y digitos
                for (var i = 0, l = digits.length; i < l; i++)
                    sum += (9 - i) * parseInt(digits[i], 10);
                return dig_ve === (10 - (sum % 10)) % 10;
            } else {
                return false;
            }
        }

    });

});