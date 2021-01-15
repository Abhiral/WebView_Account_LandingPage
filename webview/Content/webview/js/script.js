//smooth-scroll
jQuery(function ($) {
      // Add smooth scrolling to all links
      jQuery("header a, header h5, header img").on('click', function(event) {

          // Make sure this.hash has a value before overriding default behavior
          if (this.hash !== "") {
              // Prevent default anchor click behavior
              event.preventDefault();

              // Store hash
              var hash = this.hash;

              // Using jQuery's animate() method to add smooth page scroll
              // The optional number (800) specifies the number of milliseconds it takes to scroll to the specified area
              jQuery('html, body').animate({
                  scrollTop: jQuery(hash).offset().top
              }, 2500, function(){

                  // Add hash (#) to URL when done scrolling (default click behavior)
                  window.location.hash = hash;
              });
          } // End if
      });
  }); 

//hamburger menu
jQuery(document).ready(function() {
   jQuery(document).on('click', '.hamburger-menu', function(e) {
       jQuery('.menu').toggleClass('show');
        jQuery('body').toggleClass('show');
       jQuery('.hamburger-menu').toggleClass('active');
       e.stopPropagation()
   });
   jQuery(document).on('click', 'body', function(e) {
       jQuery('.menu.show').removeClass('show');
       jQuery('body.show').removeClass('show');
       jQuery('.hamburger-menu.active').removeClass('active');
       e.stopPropagation()
   });

  });


// slick.js

jQuery(document).ready(function() {

   jQuery('.slider').slick({
       slidesToShow: 4,
       slidesToScroll: 1,
       autoplay: true,
       dots: true,
       arrows: false,
       autoplaySpeed: 5000,
       prevArrow: '<div class="slick-next slick-arrow"><i class="fas fa-arrow-right"></i></div>',
       nextArrow: '<div class="slick-prev slick-arrow"><i class="fas fa-arrow-left"></i></div>',
       responsive: [
           {  
               breakpoint: 992,
               settings: {
                   slidesToShow: 3,
                   slidesToScroll: 1,
               }
           },

             {
                  breakpoint: 768,
                  settings:{
                    slidesToShow: 2,
                    slidesToScroll:1,
                  }
               },

                {
                  breakpoint: 460,
                  settings:{
                    slidesToShow: 1,
                    slidesToScroll:1,
                  }
               }
       ]
   });

});

