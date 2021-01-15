jQuery(function ($) {
    $(window).scroll(function () {
        var scroll = $(window).scrollTop();
        if (scroll >= 350) {
            $('#header').addClass('fixed-header').addClass('animated').addClass('fadeInDown');
            $('#content-wrap').addClass('m-top');

        } else {
            $('#header').removeClass('fixed-header').removeClass('animated').removeClass('fadeInDown');
            $('#content-wrap').removeClass('m-top');
        }
    });
    $('.toggle-btn').click(function(){
        $('#content-wrap').toggleClass('d-menu');
    });

    $('#menu-content > li.nav-list').click( function(){
        if ( $('#menu-content .sub-menu').hasClass('collapse').hasClass('in') ) {
            $(this).removeClass('hidden');
        } else {
            $('#menu-content .sub-menu').removeClass('hidden');
            $('#menu-content .sub-menu').addClass('hidden');
        }
    });

});