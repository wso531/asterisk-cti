<?php
	$callerid = $_GET['callerid'];
	$callername = $_GET['callername'];
	$calldata = $_GET['calldata'];
	$channel = $_GET['channel'];
	$uniqueid = $_GET['uniqueid'];
                
?>
<html>
<head>
	<title>AstCTIClient Demo context page</title>
</head>
<body>
<b>Callerid</b>: <?php echo $callerid;?><br>
<b>CalleridName</b>: <?php echo $callername;?><br>
<b>Call Data</b>: <?php echo $calldata;?><br>
<b>Channel</b>: <?php echo $channel;?><br>
<b>Unique Call Id</b>: <?php echo $uniqueid;?><br>
</body>
</html>