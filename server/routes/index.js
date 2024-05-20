var express = require("express");
var router = express.Router();

const CRUD = require("../util/jsonCRUD");

// 요청
router.get("/", function (req, res, next) {
  // 데이터 추가 함수 호출
  CRUD.addData();
  res.render("index", { title: "Express" });
});

module.exports = router;
