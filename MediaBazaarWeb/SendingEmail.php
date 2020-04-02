<?php

session_start();

require('static/php/dbConnection.php');

$username = $_SESSION['username'];
$password = $_SESSION['password'];

$query_employee = "SELECT * FROM employee WHERE Username = '$username' AND Password = '$password'";
$employee_statement = $conn->prepare($query_employee);
$employee_statement->execute();
$employees = $employee_statement->fetchAll();
$employee_statement->closeCursor();  


$emailAddress="media.bazaar2020@gmail.com";
$subject=$_POST['Subject'];
$emailContent=$_POST['emailContent'];

mail($emailAddress,$subject, $emailContent); 

?>