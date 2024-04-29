<?php
if ($_SERVER['REQUEST_METHOD'] !== 'POST') {
    die('Only POST requests are allowed');
}

$username = $_POST['username'];
$password = $_POST['password'];

header('Content-Type: application/json');
echo json_encode([
    'message' => "Tried logging in as {$username}",
    'password_strength' => strlen($password) > 10 ? 'strong' : 'weak',
    'success' => $password === 'hunter12'
]);
