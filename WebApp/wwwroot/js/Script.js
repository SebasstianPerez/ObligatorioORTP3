window.onload = function () {
    var slcTipo = document.querySelector("#slcTipo");
    var divAgencia = document.querySelector("#divAgencia");
    var divDireccionPostal = document.querySelector("#divDireccionPostal");

    function actualizarVisibilidad() {
        var selectedValue = slcTipo.options[slcTipo.selectedIndex].text;

        console.log("Selected value: " + selectedValue);

        divAgencia.style.display = "none";
        divDireccionPostal.style.display = "none";

        if (selectedValue === "Comun") {
            divAgencia.style.display = "block";
        } else if (selectedValue === "Urgente") {
            divDireccionPostal.style.display = "block";
        }
    }

    if (slcTipo) {
        slcTipo.addEventListener("change", actualizarVisibilidad);

        actualizarVisibilidad();
    }
};
