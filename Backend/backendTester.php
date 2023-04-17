<?php

// Set the response header to JSON
header('Content-Type: application/json');

// Get the HTTP method
$method = $_SERVER['REQUEST_METHOD'];

// Get the requested resource path
$request = $_SERVER['REQUEST_URI'];

// Parse the request URL
$urlParts = parse_url($request);

// Extract the path and remove leading and trailing slashes
$path = trim($urlParts['path'], '/');

// Split the path by slashes to get the resource and ID (if present)
$pathParts = explode('/', $path);
$resource = isset($pathParts[3]) ? $pathParts[3] : '';
$id = isset($pathParts[4]) ? $pathParts[4] : '';

// Initialize the response data
$response = array();

// Handle CRUD operations based on the HTTP method
switch ($method) {
    case 'POST':
        // Create a new resource
        if ($resource === 'tags') {
            // Example: Create a tag-item combination
            // TODO: Code here to create new combination of EPC and actual item in DB
            $response['message'] = 'New item created successfully';
        } else {
            http_response_code(404);
            $response['error'] = 'Resource not found';
        }
        break;

    case 'GET':
        // Read a resource or get a list of resources
        if ($resource === 'tags') {
            if (!empty($id)) {
                // Example: Read a specific tag-related item by TagID/EPC
                // Your code here to retrieve tag data from the database by TagID/EPC
                $response['message'] = 'Read tag with ID ' . $id;
            } else {
                // Example: Get a list of all tags(or probably items better)
                // Your code here to retrieve all tags/items from the database
                $response['message'] = 'List all tags or items';
            }
        } else {
            http_response_code(404);
            $response['error'] = 'Resource not found';
        }
        break;

    case 'PUT':
        // Update a resource
        if ($resource === 'tags' && !empty($id)) {
            // Example: Update a item by ID
            // Your code here to update item data in the database with data from the request body
            $response['message'] = 'Item updated successfully';
        } else {
            http_response_code(404);
            $response['error'] = 'Resource not found';
        }
        break;

    case 'DELETE':
        // Delete a resource
        if ($resource === 'tags' && !empty($id)) {
            // Example: Delete a item by TagID/EPC
            // Your code here to delete Item/Tag data from the database by ID
            $response['message'] = 'Item deleted successfully';
        } else {
            http_response_code(404);
            $response['error'] = 'Resource not found';
        }
        break;

    default:
        // Unsupported HTTP method
        http_response_code(400);
        $response['error'] = 'Unsupported HTTP method';
        break;
}

// Convert the response data to JSON and output
echo json_encode($response);