function f1() {
    LogAdmin();
    return false;
}
function LogAdmin() {
    var str = "admin";
    if ((($("#name").val()) == str) && (($("#pass").val()) == str)) {
        document.getElementById("DiscountsTable").style.display = 'block';
        document.getElementById("UsersTable").style.display = 'block';

        return false;


    }
    else {
        swal("The Name or the Password is wrong", "", "error");

    }
    return false;
}