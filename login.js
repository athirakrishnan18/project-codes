
		
	function login(){
        checkemail();
		checkpassword();
           }

/*
var  email= document.forms['form']['uname'];
var  password= document.forms['form']['paswrd'];

var email_error=document.getElementById('email_error');
var pass_error=document.getElementById('pass_error');
function validate()*/
function checkemail() {
    let loginemail_input = document.getElementById("login_email");
    let login_email_value = loginemail_input.value.trim();
    let log_small = document.getElementById("email_error");
    if (login_email_value === "") {
        logError(log_small, "Email is Empty");
    }
    else {
        var mailformat = /^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/;//regex from email
        if (login_email_value.match(mailformat)) {
            Success(log_small);
        }
        else {
            logError(log_small, "Invalid email format");
        }
    }
}
function logError(log_small, message) {
    let button = document.getElementById("submit")
    button.disabled=true
    log_small.className = 'smallshown';
    log_small.innerHTML = message;

}
function Success(log_small) {
    let button = document.getElementById("submit")
    log_small.className = 'smallhidden';
    button.disabled = false


}
/*For checking password vslidation*/


function checkpassword() {

    let passwordinput = document.getElementById("paswrd")
    let password_value = passwordinput.value.trim();
    let small_paswrd = document.getElementById("paswrd_error")
    if (password_value === "") {
        pError(small_paswrd, "Password is Empty ");
    } else {
        passSuccess(small_paswrd);
    }

}
    function pError(pass_small, message) {
    let button = document.getElementById("submit")
    button.disabled = true
    pass_small.className = 'smallshown';
    pass_small.innerHTML = message;
}
function passSuccess(pass_small) {
    let button = document.getElementById("submit")
    pass_small.className = 'smallhidden';
    button.disabled = false
}

/*Registration form validation*/
			function checkname(){					//Name validation
				let names=document.registration_form.pname.value;
				let newerror = document.getElementById("errormsg");
				let button  =document.getElementById("submit");
					if(names=== "")
					{
						/*alert("field cannot be empty");
						
						 Error(newerror, "Email is Empty");*/
						newerror.textContent="Field cannot be empty";
					}
				else{
					success(names,button);
				}
				
				function success(names,button){
					if(!isNaN(names)){
						newerror.textContent = "enter a string value";
						button.disabled=true;
					}
					else{
						newerror.textContent = "";
					}
				
			}
				}

/*Validation for date field starts*/
					function checkdate(){
					let rdate=document.registration_form.reg_date.value;
					let dterror=document.getElementById("date_error");
					let button=document.getElementById("submit");
						if(rdate===""){
							dterror.textContent="Please select Date of Birth";
							button.disabled=true;
						}
					else {
						dterror.textContent="";
						button.disabled=false;
					}
					
				}
/* Validation for Address field starts*/

function checkaddress() {								//To check if textbox contains number field
			let addresscheck = document.registration_form.address.value;
            let adrreserror = document.getElementById("erroraddress");
			let addressmatch = addresscheck.match(/\d+/g);
            let button = document.getElementById("submit");
			if (addresscheck === "") {
				adrreserror.textContent = "Field cannot be empty";
				button.disabled = true;
			}
            else if (addressmatch != null) {
				adrreserror.textContent = "Number not allowed";
				button.disabled = true;
			}
			else {
                adrreserror.textContent = "";
                button.disabled = false;
            }
        }


/*Valdation for city field starts-*/
function checkcity() {								//To check if textbox contains number field
			let citycheck = document.registration_form.city.value;
            let cerror = document.getElementById("cityerror");
			let citymatch = citycheck.match(/\d+/g);
            let button = document.getElementById("submit");
			if (citycheck === "") {
				cerror.textContent = "Field cannot be empty";
				button.disabled = true;
			}
            else if (citymatch != null) {
				cerror.textContent = "Number not allowed";
				button.disabled = true;
			}
			else {
                cerror.textContent = "";
                button.disabled = false;
            }
        }
/*Validation for phone number field*/
function checkcontactnumber() {
			let number = /^\d+$/;
			let contactnumber = document.registration_form.contact.value;
			let errormsg = document.getElementById("contacterror");
            let button = document.getElementById("submit")
			if (contactnumber === "") {
				errormsg.textContent = "Field cannot be empty";
                button.disabled = true;
			}
			
            else if (contactnumber.match(number))
        	{
                errormsg.textContent = "";
            
            }
            else {
				//errorset(contactnumber."invalid");
                errormsg.textContent = "Invalid";
                button.disabled = true;
			}
}
/*Validation for registration form email field*/
function regemail(){
	 let regemail_input = document.getElementById("reg_email");
    let regemail_value = regemail_input.value.trim();
    let regsmall = document.getElementById("reg_emailerror");
    if (regemail_value === "") {
		regsmall.textContent = "Field cannot be empty";
        //Error(regsmall, "Email is Empty");
    }
    else {
        var mailformat = /^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/;//regex from email
        if (regemail_value.match(mailformat)) {
            Success(regsmall)
        }
        else {
            Error(regsmall, "Invalid email format");
        }
    }
}
function Error(regsmall, message) {
    let button = document.getElementById("submit")
    button.disabled=true
    small.className = 'smallshown';
    small.innerHTML = message;

}
function Success(regsmall) {
    let button = document.getElementById("submit")
    small.className = 'smallhidden';
    button.disabled = false


}


function checkselection(){
        	let button = document.getElementById("submit");
            if (document.registration_form.dept.selectedIndex == "") {
                selecterror.textContent = "Field cannot be empty";
                button.disabled = true;
            }
	else{
		 		selecterror.textContent = "";
                button.disabled = false;
	}
           
        }
function register(){
	checkname();
	checkdate();
	checkaddress();
	checkcity();
	checkcontactnumber();
	regemail();
	checkselection();
}


