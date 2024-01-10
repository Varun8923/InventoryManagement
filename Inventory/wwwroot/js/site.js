// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web ~.

// Write your JavaScript code.


//$(document).ready(function () {
//    $("#txt_EmailId").val('');
//    $("#passcode_box").hide();
//    $("#sendpasscodeid").text("Send Passcode")
//    $("#sendpasscodeid").attr("onclick", "SendPasscode()");
//    $("#resendpassid").hide();
//})

    function VerifyPasscoe(genratedpasscode) {
    var inputpasscode = document.getElementById("Passocdevalue").value;
   /* inputpasscode.addEventListener('keyup', function () {*/
        //const maxLength = 4; // Set your desired character length
        //const currentLength = this.value.length;
        if (inputpasscode == genratedpasscode && inputpasscode.length == 4) {
            var element1 = document.getElementById("Emaildiv");
            var element2 = document.getElementById("Passcodediv");
            var element3 = document.getElementById("Passworddiv");
            var element4 = document.getElementById("ConfirmPassworddiv");
            var element5 = document.getElementById("submitdiv");
            var element6 = document.getElementById("outsubmitdiv");
            element1.style.display = "none";
            element2.style.display = "none";
            element6.style.display = "none";
            element3.style.display = "block";
            element4.style.display = "block";
            element5.style.display = "block";


            //document.getElementById("Emaildiv").style.visibility = "none";  
            //document.getElementById("Passcodediv").style.visibility = "none";  
            //document.getElementById("outsubmitdiv").style.visibility = "none";  
            //document.getElementById("Passworddiv").style.visibility = "block";  
            //document.getElementById("ConfirmPassworddiv").style.visibility = "block";  
            //document.getElementById("submitdiv").style.visibility = "block";  

        }
        else {

            if (inputpasscode.length < 4) {
                alert('Passcode should be at least 4 digits.');

            }
            else if (inputpasscode.length == 4)
                alert('Invalid passcode');
        }
    
}
    function validateforgotform() {
    
    if ($("#Passwordvalue").val() == null || $("#Passwordvalue").val() == "" || $("#Passwordvalue").val() == undefined) {
        alert("Please enter new passowrd");
        $("#Passwordvalue").focus();
        return false;
    }
    else if ($("#confirmpassword").val() == null || $("#confirmpassword").val() == "" || $("#confirmpassword").val() == undefined) {
        alert("Please enter confirm passowrd");
        $("#confirmpassword").focus();
        return false;
    }
    else if ($("#Passwordvalue").val().trim() != $("#confirmpassword").val().trim()) {
        alert("Please enter same new password and confirm passowrd");
        return false;
    }
    else if ($("#Passwordvalue").val().trim() == $("#confirmpassword").val().trim()) {
        var element5 = document.getElementById("savenewpass");
        var element6 = document.getElementById("verifybutton");
        element6.style.display = "none";
        element5.style.display = "block";

        
    }
    else
    {
        return true;
    }
}
    function validatePassword(password) {
        // Regular expression for password validation (minimum 8 characters, at least one uppercase, one lowercase, one number, and one special character)
        var regex = /^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!@#$%^&*]).{8,}$/;
        return regex.test(password);
}

function ReSendPasscode() {
    
    var eml = $("#Emailid").val();
    //alert(eml);
    if (eml != null && eml != "") {
        $.post("/Pages/ResendPasscode", { EmailId: eml }, function (res) {
            if (res) {
                 alert("Passcode sent successfully");
                        
                    
                    
                
            }
        })
    }
    else {
        alert("Please enter email id");
    }


    //Start : send mail code with loader 


    //End : send mail code with loader 

}


