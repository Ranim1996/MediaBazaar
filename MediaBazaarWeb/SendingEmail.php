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