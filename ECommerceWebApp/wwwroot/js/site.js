document.addEventListener("DOMContentLoaded", function () {
    // Sayfa yüklendiğinde çalışacak kodları buraya ekleyin

    // Örnek: Kullanıcıyı başka bir sayfaya yönlendirme
    var isLoggedIn = true;  // Kullanıcının giriş yapmış olup olmadığını kontrol etmek için örnek bir değişken

    if (isLoggedIn) {
        // Giriş işlemi tamamlandığında ve URL "Accounts/SignIn" veya "Accounts/SignUp" ise ana sayfaya yönlendir
        var currentUrl = window.location.href;

        if (currentUrl.includes("Accounts/SignIn") || currentUrl.includes("Accounts/SignUp")) {
            window.location.href = "/Home/Index";  // Yönlendirilecek sayfanın adresini belirtin
        }
    }
});






