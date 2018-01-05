function goTop() {
    var elem = document.getElementById("goTop");
    elem.style.scrollTop = 0;
}

function HideAllArticles() {
    var text = document.getElementsByClassName("card-text")[0];
    var fontSize = parseInt(window.getComputedStyle(text).getPropertyValue("font-size"), 10);

    var articles = document.getElementsByClassName("card-body");

    //1.3 - typical size of line-heigh with 'normal' value
    var line = (1.3 * fontSize) + fontSize;

    for (var i = 0; i < articles.length; i++) {

        var articleHeight = parseInt(window.getComputedStyle(articles[i]).getPropertyValue("height"), 10);

        if (articleHeight <= line * 5) {
            continue;
        }
        articles[i].style.height = (line * 5) + "px";
        articles[i].style.overflow = "hidden";
    }
}

function HideOneArticle(id) {
    var text = document.getElementsByClassName("card-text")[0];
    var fontSize = parseInt(window.getComputedStyle(text).getPropertyValue("font-size"), 10);

    var article = document.getElementById(id).getElementsByClassName("card-body")[0];

    //1.3 - typical size of line-heigh with 'normal' value
    var line = (1.3 * fontSize) + fontSize;

    var button = document.getElementById(id).getElementsByClassName("accordeon")[0];

    var articleHeight = parseInt(window.getComputedStyle(article).getPropertyValue("height"), 10);

    if (articleHeight <= line * 5) {
        button.innerHTML = "Show";
        return;
    }

    article.style.height = (line * 5) + "px";
    article.style.overflow = "hidden";

    button.innerHTML = "Show";
}

function ShowOneArticle(id) {
    var card = document.getElementById(id).getElementsByClassName("card-body")[0];
    card.style.removeProperty("height");

    var button = document.getElementById(id).getElementsByClassName("accordeon")[0];
    button.innerHTML = "Hide";
}

function ChangeDisplayingArticle(id) {

    var button = document.getElementById(id).getElementsByClassName("accordeon")[0];

    if (button.innerHTML === "Show") {
        ShowOneArticle(id);
    } else {
        HideOneArticle(id);
    }
}