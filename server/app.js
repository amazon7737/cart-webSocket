var createError = require("http-errors");
var express = require("express");
var path = require("path");
var cookieParser = require("cookie-parser");
var logger = require("morgan");
var cors = require("cors");

const schedule = require("node-schedule");

/**
 * WebSocket
 *
 *
 *
 */

// const whitelist = [
//   "http://localhost:3000",
//   "http://20.30.34.117:8000",
//   "http://20.30.3.171:8000",
//   "*",
// ];

// const corsOptions = {
//   origin: function (origin, callback) {
//     if (!origin || whitelist.indexOf(origin) !== -1) {
//       callback(null, true);
//     } else {
//       callback(new Error("Not allowed by CORS"));
//     }
//   },
//   credentials: true,
// };

let fs = require("fs");

const { WebSocketServer } = require("ws");
const wss = new WebSocketServer({ port: 8000 });

const WhileGame = require("./util/WhileGame");
const CRUD = require("./util/jsonCRUD");

// 연결고리
wss.on("connection", (ws) => {
  // 1초당 계속 데이터를 send 함
  const job = schedule.scheduleJob("*/1 * * * * *", function () {
    ws.send(JSON.stringify(CRUD.selectData()));
  });

  // client가 전송하는 메시지 서버로그 뜨는지 확인
  ws.on("message", (data) => {
    console.log(Buffer.from(data).toString());
  });
});

/**
 *
 *
 *
 *
 *
 */

var indexRouter = require("./routes/index");
var usersRouter = require("./routes/users");
const { get } = require("http");

var app = express();

// view engine setup
app.set("views", path.join(__dirname, "views"));
app.set("view engine", "ejs");

// cors
// app.use(cors(corsOptions));

app.use(logger("dev"));
app.use(express.json());
app.use(express.urlencoded({ extended: false }));
app.use(cookieParser());
app.use(express.static(path.join(__dirname, "public")));

app.use("/", indexRouter);
app.use("/users", usersRouter);

// catch 404 and forward to error handler
app.use(function (req, res, next) {
  next(createError(404));
});

// error handler
app.use(function (err, req, res, next) {
  // set locals, only providing error in development
  res.locals.message = err.message;
  res.locals.error = req.app.get("env") === "development" ? err : {};

  // render the error page
  res.status(err.status || 500);
  res.render("error");
});

module.exports = app;
