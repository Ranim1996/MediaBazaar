<!DOCTYPE html>
<html lang="en">
<head>
  <link rel="stylesheet" type="text/css" href="static/css/main.css">
  <link rel="stylesheet" type="text/css" href="static/css/normalize.css">
  <link rel="stylesheet" type="text/css" href="static/css/ionicons-master/docs/css/ionicons.min.css">
  <link href="https://fonts.googleapis.com/css?family=Lato:100,300,300i,400&display=swap" rel="stylesheet">
  <meta charset="UTF-8">
  <meta name="viewport" content="width=device-width,initial-scale=1,maximum-scale=1,user-scalable=no">
  <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">
  <meta name="HandheldFriendly" content="true">
  <title>Media Bazaar</title>
</head>
<body class="body-login-page">

  <div class="container">
    
    <div class="flex-container">
      <div class="company-logo">

      </div>
    </div>

      <form action="<?=$_SERVER['PHP_SELF'];?>" method="POST">
        <ul class="list">
          <li><h2 id="login-heading">Employee login</h2></li>
          <li><input type="text" name="username" placeholder="Username" id="username" required> </li>
          <li><input type="password" name="password" placeholder="Password" id="password" required></li>
          <?php 
          require('./static/php/dbConnection.php');
//header('location: homePage.php');
//include('mediaBazaar/homePage.php');
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
        $query = "SELECT * FROM employee WHERE username = :username AND password = :password AND ReasonsForRelease is NULL";
        
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
            $_SESSION['loggedin'] = TRUE;
            $_SESSION['password'] = $_POST['password'];
            $_SESSION['username'] = $_POST["username"];
          header('Location: homePage.php');
            exit;
            //echo "Profile page";
        }
        else
        {
            $message = "Wrong data inserted";
            //or the employee is fired
            echo $message;
        }
    }
}
?>
          <li><input type="submit" name="submit" value="Submit"></li>
        </ul>
      </form>
  </div>
</body>
</html>