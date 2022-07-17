function checkname(){
				let names=document.jstest.jname.value;
				let newerror = document.getElementById("errormsg");
				let button  =document.getElementById("btnsubmit");
					if(names=== "")
					{
						/*alert("field cannot be empty");
						
						 Error(newerror, "Email is Empty");*/
						newerror.textContent="Field cannot be empty";
					}
				else{
					success(names);
				}
				
				function success(names,button){
					if(!isNaN(names)){
						newerror.textContent = "enter a string value";
						button.disabled=true;
					}
					else{
						newerror.textContent = "ok";
					}
				
			}
				}