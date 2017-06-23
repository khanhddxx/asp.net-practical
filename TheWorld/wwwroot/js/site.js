// site.js
(function () {
  //$("#username").text("Khanhdd");

  //$("#main").on("mouseenter", function () {
  //  main.style.backgroundColor = "#888";
  //}).on("mouseleave", function () {
  //  main.style.backgroundColor = "";
  //});

  //$("ul.menu li a").on("click", function () {
  //  alert($(this).text());
  //});

  var $sidebarAndWrapper = $("#sidebar,#wrapper");
  var $icon = $("#sidebarToggle i.fa");

  $("#sidebarToggle").on("click", function () {
    $sidebarAndWrapper.toggleClass("hide-sidebar");
    if ($sidebarAndWrapper.hasClass("hide-sidebar")) {
      $icon.removeClass("fa-angle-left");
      $icon.addClass("fa-angle-right");
    }
    else {
      $icon.addClass("fa-angle-left");
      $icon.removeClass("fa-angle-right");
    }
  });
})();

