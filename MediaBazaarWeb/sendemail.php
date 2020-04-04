<?php
    $msg = "";
	use PHPMailer\PHPMailer\PHPMailer;
	include_once "PHPMailer/PHPMailer.php";
	include_once "PHPMailer/Exception.php";

	if (isset($_POST['submit'])) {
		$subject = $_POST['subject'];
		$email = $_POST['email'];
		$message = $_POST['message'];

		$mail = new PHPMailer();
		$mail->addAddress('media.bazaar2020@gmail.com');
		$mail->setFrom($email);
		$mail->Subject = $subject;
		$mail->isHTML(true);
		$mail->Body = $message;
			
		if ($mail->send())
		{
			$msg = "Your email has been sent, thank you!";
		}	
		else
		{
			$msg = "Please try again!";
		}			
	}
?>
<!doctype html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport"
          content="width=device-width, user-scalable=no, initial-scale=1.0, maximum-scale=1.0, minimum-scale=1.0">
    <meta http-equiv="X-UA-Compatible" content="ie=edge">
    <title>Contact Form</title>
	<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0-beta/css/bootstrap.min.css" integrity="sha384-/Y6pD6FV/Vv2HJnA6t+vslU6fwYXjCFtcEpHbNJ0lyAFsXTsjBbfaDjzALeQsN6M" crossorigin="anonymous">
</head>
<body>
	<div class="container" style="margin-top: 100px">
		<div class="row justify-content-center">
			<div class="col-md-6 col-md-offset-3" align="center">
				<img src="images/logo.png"><br><br>

                <?php if ($msg != "") echo "$msg<br><br>"; ?>

				<form method="post" action="sendemail.php" >
					<input class="form-control" name="subject" placeholder="Subject..."><br>
					<input class="form-control" name="email" type="email" placeholder="Email..."><br>
					<textarea placeholder="Message..." class="form-control" name="message"></textarea><br>
					<input class="form-control" type="file" name="attachment"><br>
					<input class="btn btn-primary" name="submit" type="submit" value="Send Email">
				</form>
			</div>
		</div>
	</div>
</body>
</html>






