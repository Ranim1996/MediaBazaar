//when pressing the button, change the paragraphs into form input fields which will have same values as the paragraph at the beginning
//add a submit button which will make the confirmation after pressing it
//when pressing the submit button the data will be updated in the database

//1) create input fields and buttons
function modifyContent(elem) {
  var element = document.getElementById(elem);
  var text = element.textContent;

  //create form
  var formElement = document.createElement("form");
  formElement.className = "formUpdate update-fields";
  formElement.setAttribute("method", "post");
  formElement.setAttribute("action", "updateInfo.php");

  //create 2 list elements
  //one for input element, one for submit button
  let liInput = document.createElement("li");
  var input = document.createElement("input");
  input.type = "text";
  input.value = text;
  input.size = Math.max(text.length);
  liInput.appendChild(input);
  formElement.appendChild(liInput);

  //create submit button
  let liSubmit = document.createElement('li');
  var submitBtn = document.createElement("input");
  submitBtn.setAttribute("type", "submit");
  submitBtn.setAttribute("value", "Update");
  submitBtn.className = "updateBtn";
  liSubmit.appendChild(submitBtn);
  formElement.appendChild(liSubmit);

  element.parentNode.replaceChild(formElement, element);
}

//update personal BIO
function updateBio(elem){
  var element = document.getElementById(elem);
  var text = element.textContent;

  console.log(text);
  debugger;
  //create form
  var formElement = document.createElement("form");
  formElement.className = "formUpdate update-fields";
  formElement.setAttribute("method", "post");
  formElement.setAttribute("action", "updateInfo.php");

  //create 2 list elements, 1 text area and 1 button
  let liInput = document.createElement("li");
  var textArea = document.createElement('textarea');
  textArea.id = "textArea-bio";
  textArea.type = "text";
  textArea.value = text;
  textArea.size = Math.max(text.length);
  liInput.appendChild(textArea);
  formElement.appendChild(liInput);

  //create submit button
  let liSubmit = document.createElement('li');
  var submitBtn = document.createElement("input");
  submitBtn.setAttribute("type", "submit");
  submitBtn.setAttribute("value", "Update");
  submitBtn.className = "updateBtn";
  liSubmit.appendChild(submitBtn);
  formElement.appendChild(liSubmit);

  element.parentNode.replaceChild(formElement, element);
}

//--- PASSWORD UPDATE FIELDS ---
function insertAfter(newNode, referenceNode) {
  referenceNode.parentNode.replaceChild(newNode, referenceNode.nextSibling);
}

function updatePassword(elem){
  var element = document.getElementById(elem);
  var text = element.value;
  //var text = element.value;

  //create form elements
  //list

  //2) label - New password
  //3) new password textBox
  //4) label - Confirm new password
  //5) confirm new password textBox
  //6) Update button

  //create form
  var formElement = document.createElement("form");
  formElement.className = "formUpdate updateFields";
  formElement.setAttribute("method", "post");
  formElement.setAttribute("action", "updateInfo.php");

  //create list
  //1)

  //2)
  let liNewPassLabel = document.createElement('li');
  var lblNewPass = document.createElement('label');
  lblNewPass.id = "password-update-label";
  lblNewPass.textContent = "New password";
  liNewPassLabel.appendChild(lblNewPass);
  formElement.appendChild(liNewPassLabel); 

  //3)
  let liInputNewPass = document.createElement("li");
  //input new pass
  var inputNewPass = document.createElement('input');
  inputNewPass.type = "password";
  inputNewPass.className = "input-pass";
  inputNewPass.id = "new-password";
  inputNewPass.className = "input-new-pass-field";
  liInputNewPass.appendChild(inputNewPass);
  //eye icon
  var showIconNewPass = document.createElement('i');
  showIconNewPass.className = "fa fa-eye";
  showIconNewPass.id = "show-icon-new-pass";
  liInputNewPass.appendChild(showIconNewPass);
  //label for password strenght
  var labelPasswordStrength = document.createElement('label');
  labelPasswordStrength.setAttribute('for', 'new-password');
  labelPasswordStrength.id = "password-strength";
  liInputNewPass.appendChild(labelPasswordStrength);
  //append these 2 to the formElement
  formElement.appendChild(liInputNewPass);

  //4)
  /* let liConfirmNewPassLabel = document.createElement('li');
  var lblConfirmNewPass = document.createElement('label');
  lblConfirmNewPass.id = "password-update-label";
  lblConfirmNewPass.textContent = "Confirm new password";
  liConfirmNewPassLabel.appendChild(lblConfirmNewPass);
  formElement.appendChild(liConfirmNewPassLabel);
  
  //5)
  let liInputConfirmNewPass = document.createElement("li");
  var inputConfirmNewPass = document.createElement('input');
  inputConfirmNewPass.type = "password";
  inputConfirmNewPass.className = "input-pass";
  inputConfirmNewPass.id = "input-confirm-new-pass-field";
  //eye icon
  var showIconConfirmPass = document.createElement('i');
  showIconConfirmPass.className = "fa fa-eye";
  showIconConfirmPass.id = "show-icon-confirm-pass";  
  liInputConfirmNewPass.appendChild(inputConfirmNewPass);
  liInputConfirmNewPass.appendChild(showIconConfirmPass);
  formElement.appendChild(liInputConfirmNewPass);
*/

  //6)
  let liSubmit = document.createElement('li');
  var submitBtn = document.createElement("input");
  submitBtn.setAttribute("type", "submit");
  submitBtn.setAttribute("value", "Update");
  submitBtn.className = "updateBtn";
  liSubmit.appendChild(submitBtn);
  formElement.appendChild(liSubmit);

 var referenceElem = document.getElementById("label-show-pass");
 insertAfter(formElement, referenceElem);

 //call the function for strenght
 document.getElementById("new-password").onkeyup = checkPasswordStrength;
 showNewPasswords('new-password', 'show-icon-new-pass');
 //showNewPasswords('input-confirm-new-pass-field', 'show-icon-confirm-pass');

}


//check password strenght
function checkPasswordStrength(){
  var newPasswordInput = document.getElementById("new-password");
  var password = newPasswordInput.value;
  var specialCharacters = ".,/;'[]?!@#$%^&*()_-+=`~";
  var passwordScore = 0;

  
  for(var i = 0; i < password.length; i++){
    if(specialCharacters.indexOf(password.charAt(i)) > -1){
      passwordScore += 20;
    }
  }

  if(/[a-z]/.test(password)){
    passwordScore += 20;
  }
  if(/[A-Z]/.test(password)){
    passwordScore += 20;
  }
  if(/[\d]/.test(password)){
    passwordScore += 20;
  }
  if(password.length >= 8){
    passwordScore += 20;
  }

  var strength = "";
  var backgroundColor = "";

  if(passwordScore >= 100){
    strength = "Strong";
    backgroundColor = "green";
  }
  else if(passwordScore >= 80){
    strength = "Medium";
    backgroundColor = "gray";
  }
  else if(passwordScore >= 60){
    strength = "Weak";
    backgroundColor = "maroon";
  }
  else{
    strength = "Very weak";
    backgroundColor = "red";
  }
  
  document.getElementById("password-strength").innerHTML = strength;
  newPasswordInput.style.backgroundColor = backgroundColor;
}

function showNewPasswords(passwordId, iconId){
  var password = document.getElementById(passwordId);
  var eye = document.getElementById(iconId);

  eye.addEventListener('click', togglePass);

  function togglePass(){

    eye.classList.toggle('active');

    (password.type == 'password') ? password.type = 'text' : password.type = 'password';
  }
}

//show the password when checkbox check changes
function showPassword(){
  var pass = document.getElementById("original-input-pass");
  var check = document.getElementById("check");
  if(check.checked)
  {
    pass.setAttribute('type', 'text');
  }
  else
  {
    pass.setAttribute('type', 'password');
  }
}

//new password checking before updating the old password

//var newPass = document.getElementsByClassName("input-new-pass-field");
//different functions have to be made for password and bio
//bio using textfield and password using input type - password

//customizing profile page content buttons 
document.getElementById("custom-contact-email").addEventListener('click', function(){ modifyContent('mail-written'); }, false);
document.getElementById("custom-contact-phone").addEventListener('click', function(){ modifyContent('phone-nr'); }, false);
document.getElementById("custom-username").addEventListener('click', function(){ modifyContent('username'); }, false);
document.getElementById("custom-password").addEventListener('click', function(){ updatePassword('original-input-pass'); }, false);
document.getElementById("custom-bio").addEventListener('click', function(){ updateBio('personal-bio'); }, false);
//checkbox check changed show/hide password
document.getElementById("check").addEventListener('click', showPassword);
