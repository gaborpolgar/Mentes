var http = require("http");
var express = require('express');
var app = express();
var mysql      = require('mysql');
var bodyParser = require('body-parser');

/* //dbServer.js-be kéne
const bcrypt = require("bcrypt")
app.use(express.json())
//middleware to read req.body.<params>
//CREATE USER
app.post("/createUser", async (req,res) => {
const user = req.body.name;
const hashedPassword = await bcrypt.hash(req.body.password,10);
db.getConnection( async (err, connection) => {
 if (err) throw (err)
 const sqlSearch = "SELECT * FROM felhasznalok WHERE felhasznalo = ?"
 const search_query = mysql.format(sqlSearch,[user])
 const sqlInsert = "INSERT INTO felhasznalok VALUES (0,?,?)"
 const insert_query = mysql.format(sqlInsert,[user, hashedPassword])
 // ? will be replaced by values
 // ?? will be replaced by string
 await connection.query (search_query, async (err, result) => {
  if (err) throw (err)
  console.log("------> Search Results")
  console.log(result.length)
  if (result.length != 0) {
   connection.release()
   console.log("------> User already exists")
   res.sendStatus(409) 
  } 
  else {
   await connection.query (insert_query, (err, result)=> {
   connection.release()
   if (err) throw (err)
   console.log ("--------> Created new User")
   console.log(result.insertId)
   res.sendStatus(201)
  })
 }
}) //end of connection.query()
}) //end of db.getConnection()
}) //end of app.post() */

// itt a vége 


//mysql kapcsolat léterhozása
var connection = mysql.createConnection({
  host     : 'localhost', 
  user     : 'root',
  password : '', 
  database : 'mynodejsrestdb' 
});
 
connection.connect(function(err) {
  if (err) throw err
  console.log('A csatlakozás sikerült...')
})
//a kapcsolat végetért
 
// body-parser konfiguráció megkezdése
app.use( bodyParser.json() );       //  JSON-encoded bodies támogatása
app.use(bodyParser.urlencoded({     // URL-encoded bodies támogatása
  extended: true
}));
//body-parser konfigurációnak vége
 
//app server létrehozása
var server = app.listen(3000,  "127.0.0.1", function () {
 
  var host = server.address().address
  var port = server.address().port
 
  console.log("Figyeljük a következő URI-t http://%s:%s", host, port)
 
});
 
//az összes elem lekérése
app.get('/toys', function (req, res) {
   connection.query('select * from toys', function (error, results, fields) {
	  if (error) throw error;
		  res.json(results);
	});
});
 

app.get('/toys/:id', function (req, res) {
     //console.log(req);
     connection.query('select * from toys where id=?', [req.params.id], function (error, results, fields) {
	 if (error) throw error;
	 res.end(JSON.stringify(results));
	});
});


//masik megoldas
/*
app.get('/employees/:id',(req, res) => {
  let sql = "SELECT * FROM employee WHERE id="+req.params.id;
  console.log(req.params.id);
  let query = connection.query(sql, (err, results) => {
    if(err) throw err;
    res.send(JSON.stringify({"status": 200, "error": null, "response": results}));
  });
});*/
 
//új rekord felvitele az adatbázisba
app.post('/toys', function (req, res) {
   var postData  = req.body;
   connection.query('INSERT INTO toys SET ?', postData, function (error, results, fields) {
	  if (error) throw error;
	  res.end(JSON.stringify(results));
	});
});

//meglévő elem frissítése
app.post('/toys/:id', function (req, res) {
  var postData  = req.body;
  connection.query('UPDATE toys SET ? WHERE `id`=?', postData, [req.params.id], function (error, results, fields) {
   if (error) throw error;
   res.end(JSON.stringify(results));
 });
});

//rekord törlése az adatbázisból
app.delete('/toys/:id', function (req, res) {
   console.log(req.body);
   connection.query('DELETE FROM `toys` WHERE `id`=?', [req.params.id], function (error, results, fields) {
	  if (error) throw error;
	  res.end('Törlés ok');
	});
});

