/**
 * 작성일자: 2024-05-10(금) 14:53분
 * 작성내용: json 데이터 추가 , 데이터 검색 , 데이터 초기화 함수 작성
 * 작성자: 김강민
 */

const fs = require("fs");

// 데이터 추가
exports.addData = function (getData) {
  // 데이터 읽기
  let data = fs.readFileSync("data.json");
  console.log("data:", Buffer.from(data).toString());

  // 데이터 형태 변환 (이거안하면 문자열만됨)
  const jsonData = JSON.parse(data);

  // 데이터 넣기
  jsonData.push({
    data: getData,
  });

  // 데이터 변환
  const jsonReturnData = JSON.stringify(jsonData);

  // 데이터 추가
  fs.writeFileSync("data.json", jsonReturnData, "utf-8", (err) => {
    if (err) throw err;
    console.log("added data");
  });
};

// 데이터 검색
exports.selectData = function () {
  // 데이터 읽기
  let data = Buffer.from(fs.readFileSync("data.json")).toString();

  let msgData = {
    type: 0,
    data: data,
  };

  return msgData;
};

// 데이터 초기화
exports.initData = function () {
  let data = [];

  // 데이터 초기화 덮어쓰기
  fs.writeFileSync("data.json", JSON.stringify(data), "utf-8", (err) => {
    if (err) throw err;
    console.log("초기화 완료");
  });
};
