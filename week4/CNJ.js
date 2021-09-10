const paragraphs = document.getElementsByTagName("p");

fetch("http://api.icndb.com/jokes/random/5")
  .then(res => res.json())
  .then(res => {
    console.log(res);
    for (let i = 0; i < res.value.length; i++) {
      paragraphs[i].innerHTML = res.value[i].id + ": " + res.value[i].joke;
      if (res.value[i].categories[0] == "nerdy") {
        paragraphs[i].style.fontFamily = "Consolas";
        paragraphs[i].style.color = "darkgreen";
      }
    }
  })