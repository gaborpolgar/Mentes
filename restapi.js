var http = require("http");
var express = require('express');
var app = express();
var mysql= require('mysql');
var bodyParser = require('body-parser');
const bcrypt = require("bcrypt")
const generateAccessToken = require("./generateAccessToken")

app.use(express.json())

require("dotenv").config()
const DB_HOST = process.env.DB_HOST
const DB_USER = process.env.DB_USER
const DB_PASSWORD = process.env.DB_PASSWORD
const DB_DATABASE = process.env.DB_DATABASE
const DB_PORT = process.env.DB_PORT
const db = mysql.createPool({
   connectionLimit: 100,
   host: DB_HOST,
   user: DB_USER,
   password: DB_PASSWORD,
   database: DB_DATABASE,
   port: DB_PORT
})

/* connection.connect(function(err) {
  if (err) throw err
  console.log('A csatlakozás sikerült...')
}) */

db.getConnection( (err, connection)=> {
  if (err) throw (err)
  console.log ("DB connected successful: " + connection.threadId)
  })
 
//app server létrehozása
var server = app.listen(3000,  "127.0.0.1", function () {
 
  var host = server.address().address
  var port = server.address().port
 
  console.log("Figyeljük a következő URI-t http://%s:%s", host, port)
 
});

//CREATE USER
app.post("/createUser", async (req,res) => {
  
  const felhasznalo = req.body.felhasznalonev;
  const hashedPassword = await bcrypt.hash(req.body.jelszo,10);
  db.getConnection( async (err, connection) => {
   if (err) throw (err)
   console.log("A csatlakozás sikerült");
   const sqlSearch = "SELECT * FROM felhasznalok WHERE felhasznalonev = ?"
   const search_query = mysql.format(sqlSearch,[felhasznalo])
   const sqlInsert = "INSERT INTO felhasznalok VALUES (0,?,?)"
   const insert_query = mysql.format(sqlInsert,[felhasznalo, hashedPassword])
   // ? will be replaced by values
   // ?? will be replaced by string
   await connection.query (search_query, async (err, result) => {
    if (err) throw (err)
    console.log("------> Search Results")
    console.log(result.length)
    if (result.length != 0) {
     connection.release()
     console.log("------> A felhasználó már létezik.")
     res.sendStatus(409) 
    } 
    else {
     await connection.query (insert_query, (err, result)=> {
     connection.release()
     if (err) throw (err)
     console.log ("--------> Létrejött egy új felhasználó.")
     console.log(result.insertId)
     res.sendStatus(201)
    })
   }
  }) //end of connection.query()
}) //end of db.getConnection()
}) //end of app.post()


/* //mysql kapcsolat léterhozása
var connection = mysql.createConnection({
  host     : 'localhost', 
  user     : 'root',
  password : '', 
  database : 'mynodejsrestdb' 
});
 
// body-parser konfiguráció megkezdése
app.use( bodyParser.json() );       //  JSON-encoded bodies támogatása
app.use(bodyParser.urlencoded({     // URL-encoded bodies támogatása
  extended: true
}));
//body-parser konfigurációnak vége

//az összes elem lekérése

app.get('/toys', function (req, res) {
   db.query('select * from toys', function (error, results, fields) {
	  if (error) throw error;
		  res.json(results);
      console.log(results);
	});
  console.log(results);
});
 
app.get("/toys/:id", async (req,res) => {
  db.getConnection( async (err, connection) => {
    connection.query('select * from toys where id=?', [req.params.id], function (error, results, fields) {
      if (error) throw error;
      res.end(JSON.stringify(results));
	});
})
});


/* app.get('/toys/:id', function (req, res) {
     //console.log(req);
     connection.query('select * from toys where id=?', [req.params.id], function (error, results, fields) {
	 if (error) throw error;
	 res.end(JSON.stringify(results));
	});
}); */


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
 
// body-parser konfiguráció megkezdése
app.use( bodyParser.json() );       //  JSON-encoded bodies támogatása
app.use(bodyParser.urlencoded({     // URL-encoded bodies támogatása
  extended: true
}));
//body-parser konfigurációnak vége

var bodyParser = require('express');

app.get('/toys', function (req, res) {
  db.getConnection( async (err, connection) => {

  db.query('select * from toys', function (error, results, fields) {
   if (error) throw error;
     res.json(results);
 });
});
});

app.get("/toys/:id", async (req,res) => {
  db.getConnection( async (err, connection) => {
    connection.query('select * from toys where id=?', [req.params.id], function (error, results, fields) {
      if (error) throw error;
      res.end(JSON.stringify(results));
	});
})
});

//új rekord felvitele az adatbázisba

app.post("/toys", async (req,res) => {
  db.getConnection( async (err, connection) => {
      var postData  = req.body;
      connection.query('INSERT INTO toys SET ?', postData, function (error, results, fields) {
       if (error) throw error;
       res.end(JSON.stringify(results));
     });
   });
  });


/*     app.post('/toys', function (req, res) {
   var postData  = req.body;
   connection.query('INSERT INTO toys SET ?', postData, function (error, results, fields) {
	  if (error) throw error;
	  res.end(JSON.stringify(results));
	});
}); */
 
//meglévő elem frissítése
app.put("/toys/:id", async (req,res) => {
  db.getConnection( async (err, connection) => {
  var postData  = req.body;
  connection.query('UPDATE toys SET name=? WHERE id=?', [postData, req.params.id], function (error, results, fields) {
  //connection.query('UPDATE toys SET name=? WHERE id=?', postData, postDataid, function (error, results, fields) {
   if (error) throw error;
   res.end(JSON.stringify(results));
 });
});
});

//rekord törlése az adatbázisból

app.delete("/toys/:id", async (req,res) => {
  db.getConnection( async (err, connection) => {
  // console.log(req.body);
   connection.query('DELETE FROM `toys` WHERE `id`=?', [req.params.id], function (error, results, fields) {
	  if (error) throw error;
	  res.end('Törlés ok');
	});
});
});



/* function generateAccessToken(felhasznalonev) {
  return 
  jwt.sign(felhasznalonev, process.env.ACCESS_TOKEN_SECRET, {expiresIn: "15m"}) 
  }
  // refreshTokens
  let refreshTokens = []
  function generateRefreshToken(user) {
  const refreshToken = 
  jwt.sign(user, process.env.REFRESH_TOKEN_SECRET, {expiresIn: "20m"})
  refreshTokens.push(refreshToken)
  return refreshToken
  } */

//LOGIN (A felhasználó authentikációja és hozzáférési token generálása)
app.post("/login", (req, res)=> {
  const felhasznalonev = req.body.felhasznalonev
  const jelszo = req.body.jelszo
  db.getConnection ( async (err, connection)=> {
   if (err) throw (err)
   const sqlSearch = "Select * from felhasznalok where felhasznalonev = ?"
   const search_query = mysql.format(sqlSearch,[felhasznalonev])
   await connection.query (search_query, async (err, result) => {
    connection.release()
    
    if (err) throw (err)
    if (result.length == 0) {
     console.log("--------> Ilyen felhasználó nem létezik!")
     res.sendStatus(404)
    } 
    else {
       const hashedPassword = result[0].jelszo;
       //get the hashedPassword from result
      if (await bcrypt.compare(jelszo, hashedPassword)) {
      console.log("---------> A bejelentkezés sikeres!")
      console.log(`${felhasznalonev} bejelentkezett!`)
      //res.send(`${felhasznalonev} bejelentkezett!`)
      console.log("---------> Generating accessToken")
    const token = generateAccessToken({felhasznalonev:felhasznalonev})   
    console.log(token)
    res.json({accessToken: token})
      } 
      else {
      console.log("---------> A jelszó helytelen")
      res.send("A jelszó helytelen!!")
      } //end of bcrypt.compare()
    }//end of User exists i.e. results.length==0
   }) //end of connection.query()
  }) //end of db.connection()
  }) //end of app.post()

  express.post('/get_php_data', function (req, res) {
    var data = req.body.data;
    res.send(' Done ');
});