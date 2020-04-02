//when pressing the button, change the paragraphs into form input fields which will have same values as the paragraph at the beginning
//add a submit button which will make the confirmation after pressing it
//when pressing the submit button the data will be updated in the database

//1) create input fields and buttons

function modifyContent(elem) {
  var element = document.getElementById(elem);
  var text = element.textContent;

  //create form
  var formElement = document.createElement("form");
  formElement.id = "formUpdate";
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
  submitBtn.id = "updateBtn";
  liSubmit.appendChild(submitBtn);
  formElement.appendChild(liSubmit);

  //formElement.appendChild(submitBtn);
  element.parentNode.replaceChild(formElement, element);

}

//different functions have to be made for password and bio
//bio using textfield and password using input type - password


document.getElementById("custom-contact-email").addEventListener('click', function(){ modifyContent('mail-written'); }, false);
document.getElementById("custom-contact-phone").addEventListener('click', function(){ modifyContent('phone-nr'); }, false);
document.getElementById("custom-username").addEventListener('click', function(){ modifyContent('username'); }, false);


