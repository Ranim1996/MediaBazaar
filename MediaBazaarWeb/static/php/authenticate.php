<?php 

require('dbConnection.php');
//header('location: profilePage.php');
 session_start();

if(isset($_POST['submit']))
{
    if(empty($_POST["username"]) || empty($_POST["password"]))
    {
        $message = '<label>All fields are required</label>';
        echo $message;
    }
    else
    {
        $query = "SELECT * FROM employee WHERE username = :username AND password = :password";
        $statement = $conn->prepare($query);
        $statement->execute(
            array(
                'username' => $_POST["username"],
                'password' => $_POST["password"]
            )
        );
        $count = $statement->rowCount();
        if($count > 0)
        {
            $_SESSION["username"] = $_POST["username"];
	        header('Location: /mediaBazaar/homePage.html');
            exit;
            //echo "Profile page";
        }
        else
        {
            $message = "Wrong data inserted";
            echo $message;
        }
    }
}

?>
