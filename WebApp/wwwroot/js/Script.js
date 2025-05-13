window.onload = function () {
    document.getElementById("tipoEnvioSelect").dispatchEvent(new Event("change"));
};

document.querySelectorById("tipoEnvioSelect").addEventListener("change", function () {
    var selectedValue = this.value;

    document.getElementById("txtAgencia").style.display = "none";
    document.getElementById("txtDireccionPostal").style.display = "none";

    if (selectedValue === "1") {
        document.getElementById("txtAgencia").style.display = "block";
    } else if (selectedValue === "2") {
        document.getElementById("txtDireccionPostal").style.display = "block";
    }

});