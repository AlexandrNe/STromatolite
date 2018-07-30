 /*
 * Triumph Multipurpose HTML5 Template v1.0
 * Copyright 2015 8Guild.com
 * Custom scripts for Triumph Template
 */

/* Preloader
*********************************************************************/

/*Preloading Animation*/
$(window).load(function() {
	$('.preloader').delay(300).addClass('cloak');
});

/*Document Ready*/////////////////////////////////////////////////////////////////////////////////
jQuery(document).ready(function($) {
	'use strict';

	// Checking with Modernizr if it is touch device
	// Touch Devices
	if (Modernizr.touch){

		$('*').removeClass('animation');

		// No-touch Devices
	} else {

		/* Parallax plugin init
		*********************************************************************/
		
		$(window).load(function(){
			if($("body.parallax").length > 0) {
					$("body.parallax").stellar({
						scrollProperty: 'scroll',
						 horizontalOffset: 0,
						 horizontalScrolling: false,
						responsive: true
					});
				}
		});

		/* Navbar stucking / transforming on window scroll / load (using jQuery Waypoints)
		*************************************************************************************/
		var stickyNavbar = $('.navbar-sticky');
		$(window).on('load', function(){
			if(stickyNavbar.length > 0) {
				var sticky = new Waypoint.Sticky({
				  element: stickyNavbar[0],
				  handler: function(direction) {
				  	if(direction == 'down') {
					  	stickyNavbar.removeClass('navbar-ghost');
				  	} else {
				  		stickyNavbar.addClass('navbar-ghost');
				  	}
				  }
				});
			}
		});

	} // Modernizr End

		/* Update Waypoints when notification is closed */
		$('.notification .close').on('click', function() {
			setTimeout(function() {
			  Waypoint.refreshAll();
			}, 300);
		});


    // Masonary Gallery Active Code
		if ($.fn.imagesLoaded) {
		    $('.gallery_full_width_images_area, .portfolio-column, .blog-masonary').imagesLoaded(function () {
		        // filter items on button click
		        $('.portfolio-menu').on('click', 'button', function () {
		            var filterValue = $(this).attr('data-filter');
		            $grid.isotope({
		                filter: filterValue
		            });
		        });
		        // init Isotope
		        var $grid = $('.gallery_full_width_images_area, .portfolio-column, .blog-masonary').isotope({
		            itemSelector: '.single_gallery_item, .column_single_gallery_item, .sb_masonary_item',
		            percentPosition: true,
		            masonry: {
		                columnWidth: '.single_gallery_item, .column_single_gallery_item, .sb_masonary_item'
		            }
		        });
		    });

		}
	
	/* Disable default link behavior for dummy links that have href='#'
	*********************************************************************/
	$('a[href=#], .update a').click(function(e){
		e.preventDefault();
	});

	/* Mobile Navigation Show / Hide
	*********************************************************************/
	$('.nav-toggle').on('click', function(){
		var target = $(this).find('a').data('nav-target');
		$(target).toggleClass('open');
	});

	/* Mobile Navigation Submenu Toggling
	*********************************************************************/
	$('.navbar-nav ul li a').click(function(){
		if($(this).parent().hasClass('expanded')) {
			$(this).siblings('ul, div').removeClass('open');
			$(this).parent().removeClass('expanded');
		} else {
			$(this).parent().siblings('li').removeClass('expanded');
			$(this).parent().siblings('li').find('ul, div').removeClass('open');
			$(this).siblings('ul, div').toggleClass('open');
			$(this).parent().toggleClass('expanded');
		}
	});


	/** Sign in / Sign up form switching (in modal)
	*********************************************************/
	$('.form-switch a').click(function(e){
		var form = $(this).attr('href');
		e.preventDefault();
		$(form + '> a').click();
	});


	/** Switch to Sign In/Sign Up Form when Modal open (For separate Sign In/Sign Up button)
	*****************************************************************************************/
	$('[data-modal-form="sign-in"]').click(function(){
		$('#form-2 a').click();
	});
	$('[data-modal-form="sign-up"]').click(function(){
		$('#form-1 a').click();
	});

	
	/* Tooltips 
	**************************************************************/
	if($('[data-toggle="tooltip"]').length > 0) {
		$('[data-toggle="tooltip"]').tooltip();
	}
	
	/* Popovers
	**************************************************************/
	if($('[data-toggle="popover"]').length > 0) {
		$('[data-toggle="popover"]').popover();
	}


	/* Animated Appearance of Scroll to Top Button
	**************************************************************/
	var scrollTop = $('.scroll-to-top-btn'),
			scrolledFromTop = $('.scroll-to-top-btn').data('scroll-top');
	$(window).on('scroll', function(){
    if ($(window).scrollTop() > scrolledFromTop) {
      scrollTop.addClass('visible');
    } else {
      scrollTop.removeClass('visible');
    }
	});

	/** Material Effect on Buttons
	**********************************************************/
	Waves.displayEffect();

	/** Advanced Custom Select Boxes
	**********************************************************/
	if($('.form-select').length > 0) {
		$('.form-select').selectpicker({
			width: '100%'
		});
	}

	/** Color Switches
	**********************************************************/
	if($('.color-switch').length > 0) {
		$('.color-switch').each(function(){
			var color = $(this).data('color');
			$(this).find('.iradio').css('background-color', color);
			$(this).find('.icheckbox').css('background-color', color);
		});
	}

	/** Form Validations
	**********************************************************/
	if($('#signin-form').length > 0) {
		$('#signin-form').validate();
	}
	if($('#signup-form').length > 0) {
		$('#signup-form').validate();
	}
	if($('#login-form').length > 0) {
		$('#login-form').validate();
	}
	if($('#signup-form2').length > 0) {
		$('#signup-form2').validate();
	}
	if($('#search-form').length > 0) {
		$('#search-form').validate();
	}
	if($('#comment-form').length > 0) {
		$('#comment-form').validate();
	}
	if($('#checkout-form').length > 0) {
		$('#checkout-form').validate({
			rules: {
				co_zip: {
					required: true,
					number: true
				},
				co_phone: {
					required: true,
					number: true
				}
			}
		});
	}
	if($('#calc-shipping-form').length > 0) {
		$('#calc-shipping-form').validate({
			rules: {
				cs_zip: {
					required: true,
					number: true
				}
			}
		});
	}
	if($('#coupon-form').length > 0) {
		$('#coupon-form').validate({
			rules: {
				coup_code: {
					required: true,
					number: true
				}
			}
		});
	}
	if($('#contact-form').length > 0) {
		$('#contact-form').validate();
	}
	if($('#form-demo').length > 0) {
		$('#form-demo').validate();
	}
	if($('#form-demo-2').length > 0) {
		$('#form-demo-2').validate();
	}
	if($('#subscr-widget-form').length > 0) {
		$('#subscr-widget-form').validate();
	}
	if($('#subscr-widget-form2').length > 0) {
		$('#subscr-widget-form2').validate();
	}
	if($('#subscr-widget-form3').length > 0) {
		$('#subscr-widget-form3').validate();
	}
	if($('#subscr-widget-form4').length > 0) {
		$('#subscr-widget-form4').validate();
	}
	if($('#subscr-widget-form5').length > 0) {
		$('#subscr-widget-form5').validate();
	}
	if($('#subscr-widget-form6').length > 0) {
		$('#subscr-widget-form6').validate();
	}
	if($('#subscr-widget-form7').length > 0) {
		$('#subscr-widget-form7').validate();
	}

	/** UI Sliders (Range Sliders)
	**********************************************************/
	if($('.slider-ui').length > 0) {
		$('.slider-ui input').each(function(){
			var unit = $(this).parent().data('unit'),
					unitPos = $(this).parent().data('unit-position'),
					range = $(this).parent().data('range');
			$(this).slider({
				range: range,
				formatter: function(value) {
					if(unitPos == 'before')	{
						return unit + value;
					} else if(unitPos == 'after') {
						return value + unit;
					}
				}
			});
		});
	}

	// Step Slider
	if($('.slider-ui-step').length > 0) {
		$('.slider-ui-step input').each(function(){
			$(this).slider();
		});
	}

	/** Count Input (Quantity)
	**********************************************************/
    //$(".incr-btn").on("click", function(e) {
	$(document).on("click", ".incr-btn", function(e) {
		var $button = $(this);
		var oldValue = $button.parent().find('.quantity').val();
		$button.parent().find('.incr-btn[data-action="decrease"]').removeClass('inactive');
		if ($button.data('action') == "increase") {
			var newVal = parseFloat(oldValue) + 1;
		} else {
		 // Don't allow decrementing below 1
			if (oldValue > 1) {
				var newVal = parseFloat(oldValue) - 1;
			} else {
				newVal = 1;
				$button.addClass('inactive');
			}
		}
		$button.parent().find('.quantity').val(newVal);
		$('#quantity').val(newVal);
		e.preventDefault();
	});


	/* Toggleable Switch component
	***************************************************************************/
	$('.switch').on('click', function(){

		if(!$(this).hasClass('disabled')) {

		  var clicks = $(this).data('clicks');
		  var inputVal = $(this).find('input').attr('value');
		 
			if (clicks && inputVal == 'off') {
				$(this).find('input').attr('value', 'on');
				$(this).addClass('on');
			} else if (clicks && inputVal == 'on') {
				$(this).find('input').attr('value', 'off');
				$(this).removeClass('on');
			} else if (!clicks && inputVal == 'off') {
				$(this).find('input').attr('value', 'on');
				$(this).addClass('on');
			} else if (!clicks && inputVal == 'on') {
				$(this).find('input').attr('value', 'off');
				$(this).removeClass('on');
			}

			$(this).data("clicks", !clicks);

		}
		
	});
	

	/** Progress Bars on Scroll Animation
	**********************************************************/
	function pbOnScrollAnimation( items, trigger ) {
	  items.each( function() {
	    var pbElement = $(this),
	        curVal = pbElement.find('.progress-bar').attr('aria-valuenow');
	 
	    var pbTrigger = ( trigger ) ? trigger : pbElement;
	 
	    pbTrigger.waypoint(function() {
	      	pbElement.find('.progress-bar').css({'width': curVal + '%', 'padding-left': '12px'});
	    },{
	        offset: '90%'
	    });
	  });
	}
	pbOnScrollAnimation( $('.progress-animated') );
	
	
	// On window load functions
	$(window).on('load', function(){


		/** Carousels
		**********************************************************/
		// Widget Carousel
		$('.widget-carousel .inner').each(function(){
			var navOpt = $(this).parent().data('nav'),
					dotsOpt = $(this).parent().data('dots'),
					autoPlay = $(this).parent().data('autoplay'),
					timeOut = $(this).parent().data('interval');
			$(this).owlCarousel({
		    loop: true,
		    margin: 20,
		    nav: navOpt,
		    dots: dotsOpt,
		    navText: "",
		    items: 1,
		    autoHeight: true,
		    autoplay: autoPlay,
		    autoplayTimeout: timeOut
			});
		});

		// Content Slider
		$('.content-slider').each(function(){
			var loop =  $(this).data('loop'),
					autoPlay = $(this).data('autoplay'),
					timeOut = $(this).data('interval'),
					autoHeight = $(this).data('autoheight');
			$(this).owlCarousel({
		    loop: loop,
		    margin: 0,
		    nav: true,
		    navText: "",
		    items: 1,
		    autoHeight: autoHeight,
		    autoplay: autoPlay,
		    autoplayTimeout: timeOut
			});
		});

		// Content Carousel
		$('.content-carousel').each(function(){
			var loop =  $(this).data('loop'),
					margin = $(this).data('margin'),
					navOpt = $(this).data('nav'),
					dotsOpt = $(this).data('dots'),
					slideBy = $(this).data('slideby'),
					autoPlay = $(this).data('autoplay'),
					timeOut = $(this).data('interval'),
					autoHeight = $(this).data('autoheight'),
					desktopLg = $(this).data('desktop-large'),
					desktopSm = $(this).data('desktop-small'),
					tabletLand = $(this).data('tablet-landscape'),
					tabletPort = $(this).data('tablet-portrait'),
					phoneLand = $(this).data('phone-landscape'),
					phonePort = $(this).data('phone-portrait');
			$(this).owlCarousel({
		    loop: loop,
		    margin: margin,
		    nav: navOpt,
		    dots: dotsOpt,
		    navText: "",
		    slideBy: slideBy,
		    autoplay: autoPlay,
		    autoplayTimeout: timeOut,
		    autoHeight: autoHeight,
		    responsive:{
	        0:{
	          items:phonePort
	        },
	        360:{
	          items:phoneLand
	        },
	        480:{
	          items:tabletPort
	        },
	        768:{
	          items:tabletLand
	        },
	        991:{
	          items:desktopSm
	        },
	        1200:{
	        	items:desktopLg
	        }
    		}	
			});
		});


		/** Magnific Popup Init
		**********************************************************/
		 //product Popup
		if($('.popup-ajax').length > 0) {
			$('.popup-ajax').magnificPopup({ 
			    type: 'ajax',
			    elementParse: function (item) {
			        this.st.ajax.settings = item.el.data();

			    },
			    callbacks: {
			        ajaxContentAdded: function () {

			            if ($('.product-showcase-slider').length > 0) {
			                var prodShowSlider = new MasterSlider();

			                prodShowSlider.control('arrows');
			                prodShowSlider.control('thumblist', { autohide: false, dir: 'v', arrows: false, align: 'right', width: 127, height: 137, margin: 5, space: 5, hideUnder: 520 });

			                prodShowSlider.setup('ms-product-showcase', {
			                    width: 613,
			                    height: 565,
			                    space: 5,
			                    view: 'parallaxMask'
			                });
			            };

			            $("a#order").fancybox({

			                maxWidth: 700,
			                maxHeight: 600,
			                fitToView: false,
			                width: 'auto',
			                height: 'auto',
			                autoSize: true,
			                scrolling: 'no',
			                closeClick: false,
			                openEffect: 'elastic',
			                closeEffect: 'elastic',
			                modal: true
			            });
			        }
			    }
			});
		}



        /***/
		$("a#order-call").fancybox({

		    type: 'ajax',
		    href: '/Orders/_Callback',

		    fitToView: true,
		    width: 'auto',
		    height: 'auto',
		    autoSize: true,
		    scrolling: 'no',
		    closeClick: false,
		    openEffect: 'elastic',
		    closeEffect: 'elastic',
		    modal: true
		});


		

	    /*********/

		   //var wow = new WOW(
           //         {
           //             boxClass: 'wow', // animated element css class (default is wow)
           //             animateClass: 'animated', // animation css class (default is animated)
           //             offset: 100, // distance to the element when triggering the animation (default is 0)
           //             mobile: false        // trigger animations on mobile devices (true is default)
           //         }
           // );
		   // wow.init();


		// Video Popup (iFrames)
		//if($('.popup-video').length > 0) {
		//	$('.popup-video').magnificPopup({
		//		type:'iframe',
		//		removalDelay: 300,

		//	  // Class that is added to popup wrapper and background
		//	  // apply CSS animations just to this exact popup
		//	  mainClass: 'mfp-fade'
		//	});
		//}

		
		/*Content Animations On Scroll
		*********************************************/
		function animationOnScroll( items, trigger ) {
		  items.each( function() {
		    var element = $(this),
		        animation = $(this).data("animation"),
		        delay = $(this).data("animation-delay");
		 
		    var animTrigger = ( trigger ) ? trigger : element;
		 
		    animTrigger.waypoint(function() {
		    		element.css({'-webkit-animation-delay':delay + 'ms', 'animation-delay':delay + 'ms'});
		      	element.addClass(animation).addClass('animated');
		    },{
		        offset: '82%'
		    });
		  });
		}
		animationOnScroll( $('.animation') );


		/** Masonry Grids (Isotope) + Filtering
		*********************************************************/
		// Isotope Grid Equal Columns
		if($('.isotope-grid').length > 0) {
		  $('.isotope-grid').isotope({
			  itemSelector: '.grid-item',
			  transitionDuration: '0.7s',
			  masonry: {
			    columnWidth: '.grid-sizer',
			    gutter: '.gutter-sizer'
			  }
		  });
		}

		// Masonry Grid Type 1
		if($('.masonry-grid-type-1').length > 0) {
		  $('.masonry-grid-type-1').isotope({
			  itemSelector: '.grid-item',
			  transitionDuration: '0.7s',
			  masonry: {
			    columnWidth: '.grid-sizer',
			    gutter: '.gutter-sizer'
			  }
		  });
		}

		// Masonry Grid Type 2
		if($('.masonry-grid-type-2').length > 0) {
		  $('.masonry-grid-type-2').isotope({
			  itemSelector: '.grid-item',
			  transitionDuration: '0.7s',
			  masonry: {
			    columnWidth: '.grid-sizer',
			    gutter: '.gutter-sizer'
			  }
		  });
		}

		// Filtering
		if($('.filter-grid').length > 0) {
		  var grid = $('.filter-grid');
			$('.nav-filters').on( 'click', 'a', function(e) {
				e.preventDefault();
				$('.nav-filters li').removeClass('active');
				$(this).parent().addClass('active');
			  var filterValue = $(this).attr('data-filter');
			  grid.isotope({ filter: filterValue });
			});
		}

	}); // Window load End


	/** Intro Page Slider (Master Slider with tabs)
	**********************************************************/
	if($('.intro-slider').length > 0) {

		var introSlider = new MasterSlider();

		introSlider.control('circletimer' , {color:"#FFFFFF" , stroke:9});
		introSlider.control('thumblist' , {autohide:false ,dir:'h', type:'tabs',width:168,height:210, align:'bottom', space:80 , margin:-12, hideUnder:400});

		introSlider.setup('ms-intro-slider' , {
			width: 1170,
			height:528,
			space:0,
			loop: true,
			layout:'fullwidth',
			preload:'all',
			view:'stack'
		});
	}

	/** Product Showcase Slider (Master Slider)
	**********************************************************/
	//if($('.product-showcase-slider').length > 0) {
	//	var prodShowSlider = new MasterSlider();

	//	prodShowSlider.control('arrows');	
	//	prodShowSlider.control('thumblist' , {autohide:false, dir:'v', arrows:false, align:'right', width:127, height:137, margin:5, space:5, hideUnder:520});
		
	//	prodShowSlider.setup('ms-product-showcase' , {
	//		width:613,
	//		height:565,
	//		space:5,
	//		view:'parallaxMask'
	//	});
	//}

	
	/** Laptop Slider (Master Slider)
	**********************************************************/
	if($('#laptop-slider').length > 0) {

		var laptopSlider = new MasterSlider();
		laptopSlider.setup('laptop-slider' , {
			width:492,
			height:309,
			speed:20,
			preload:0,
			space:2,
			view:'mask'
		});
		laptopSlider.control('arrows');	
		laptopSlider.control('bullets',{autohide:false});	
	}


	/** Featured Products Slider (Master Slider with tabs)
	**********************************************************/
	if($('.fp-slider').length > 0) {

		var fprodSlider = new MasterSlider();

		fprodSlider.control('circletimer' , {color:"#FFFFFF" , stroke:9});
		fprodSlider.control('thumblist' , {autohide:false ,dir:'h', type:'tabs',width:210,height:270, align:'bottom', space:80 , margin:-12, hideUnder:400});

		fprodSlider.setup('ms-featured-product' , {
			width: 1170,
			height:650,
			space:0,
			layout:'fullwidth',
			preload:'all',
			view:'parallaxMask'
		});
	}

	/** Restaurant Gallery Slider (Master Slider)
	**********************************************************/
	if($('#rest-gallery').length > 0) {
		var restGal = new MasterSlider();
		
		restGal.control('arrows');	
		restGal.control('circletimer' , {color:"#FFFFFF" , stroke:9});
		
		restGal.setup('ms-rest-gal' , {
			width:760,
			height:400,
			space:10,
			loop:true,
			view:'fadeWave',
			layout:'partialview'
		});
	}

	/** IT/Software Gallery Slider (Master Slider)
	**********************************************************/
	if($('#it-gallery').length > 0) {
		var itGal = new MasterSlider();

		itGal.control('arrows');	
		itGal.control('bullets' , {autohide:false, align:'bottom', margin:10});	

		itGal.setup('it-gallery' , {
			width:750,
			height:430,
			layout:'partialview',
			space:5,
			view:'basic',
			loop:true
		});
	}


	/** Revolution Slider
	*********************************************************/
	// Fullscreen Slider (Shop Homepage)
	if($('#fs-shop-slider').length > 0) {
		$('#fs-shop-slider').revolution({
			delay:15000,
			startwidth:1880,
			startheight:1080,
			hideThumbs:10,
			fullWidth:"off",
			fullScreen:"on",
			fullScreenOffsetContainer: "",
			navigationStyle: "preview1"
		});
	}

	// Full Width Slider (Shop Homepage)
	if($('#fw-shop-slider').length > 0) {
		$('#fw-shop-slider').revolution({
			delay:12000,
			startwidth:1700,
			startheight:650,
			hideThumbs:10,
			fullWidth:"on",
			fullScreen:"off",
			fullScreenOffsetContainer: "",
			navigationStyle: "preview4"
		});
	}

	// Fullscreen Video (Corporate Homepage)
	if($('#fs-video').length > 0) {
		$('#fs-video').revolution({
			stopAtSlide: 1,
			stopAfterLoops: 0,
			startwidth:650,
			startheight:500,
			hideThumbs:10,
			fullWidth:"off",
			fullScreen:"on",
			touchenabled:"off"
		});
	}

	// Fullscreen Slider (Corporate Homepage)
	if($('#fs-corp-slider').length > 0) {
		$('#fs-corp-slider').revolution({
			delay:12000,
			startwidth:1100,
			startheight:600,
			hideThumbs:10,
			fullWidth:"off",
			fullScreen:"on",
			fullScreenOffsetContainer: "",
			navigationStyle: "preview4"
		});
	}

	// Full Width Slider (Corporate Homepage)
	if($('#fw-corp-slider').length > 0) {
		$('#fw-corp-slider').revolution({
			delay:12000,
			startwidth:1100,
			startheight:650,
			hideThumbs:10,
			fullWidth:"on",
			fullScreen:"off",
			fullScreenOffsetContainer: "",
			navigationStyle: "preview4"
		});
	}

	// Full Width Pan Zoom Slider (Restaurant Homepage)
	if($('#fw-rest-slider').length > 0) {
		$('#fw-rest-slider').revolution({
			delay:12000,
			startwidth:1880,
			startheight:1080,
			hideThumbs:10,
			fullWidth:"off",
			fullScreen:"on",
			onHoverStop:"off",
			fullScreenOffsetContainer: ".navbar-wrap",
			navigationStyle: "preview4"
		});
	}


	///////////////////////////////////////////////////////////////////////
	/////////  INTERNAL ANCHOR LINKS SCROLLING (NAVIGATION)  //////////////
	//////////////////////////////////////////////////////////////////////
	
	$(".scroll-to").click(function(event){		
		var elem = $(this).attr('href'),
				elemOffsetTop = $(elem).data('scroll-offset-top');
		$('html').velocity("scroll", { offset:$(this.hash).offset().top-elemOffsetTop, duration: 1000, easing:'easeOutExpo', mobileHA: false});
		event.preventDefault();
	});
	$('.scroll-up').click(function(e){
		e.preventDefault();
		$('html').velocity("scroll", { offset: 0, duration: 1000, easing:'easeOutExpo', mobileHA: false });
	});
	

	//SCROLL-SPY
	// Cache selectors
	var lastId,
		topMenu = $(".scroll-nav"),
		topMenuHeight = topMenu.outerHeight(),
		// All list items
		menuItems = topMenu.find("a"),
		// Anchors corresponding to menu items
		scrollItems = menuItems.map(function(){
			if( /^#/.test($(this).attr("href")) == true) {
			  var item = $($(this).attr("href"));
			  if (item.length) { return item; }
			}
		});
	
	// Bind to scroll
	$(window).scroll(function(){
	   // Get container scroll position
	   var fromTop = $(this).scrollTop()+topMenuHeight+200;
	   
	   // Get id of current scroll item
	   var cur = scrollItems.map(function(){
		 if ($(this).offset().top < fromTop)
		   return this;
	   });
	   // Get the id of the current element
	   cur = cur[cur.length-1];
	   var id = cur && cur.length ? cur[0].id : "";
	   
	   if (lastId !== id) {
		   lastId = id;
		   // Set/remove active class
		   menuItems
			 .parent().removeClass("active")
			 .end().filter("[href=#"+id+"]").parent().addClass("active");
	   }
	});

  
	/* Counters (Animated Digits)
	**************************************************************/
	function counterOnScrollAnimation( items, trigger ) {
	  items.each( function() {
	    var counterElement = $(this),
	        decimals = $(this).data('decimals'),
	        duration = $(this).data('duration');
	 
	    var counterTrigger = ( trigger ) ? trigger : counterElement;
	 
	    counterTrigger.waypoint(function(direction) {
				  	if(direction == 'down') {
			      	counterElement.find('.digits').spincrement({
									from: 0.0,
									decimalPlaces: decimals,
									duration: duration
							});
				  	} else {
				  		this.destroy();
				  	}
	    },{
	        offset: '95%'
	    });
	  });
	}
	counterOnScrollAnimation( $('.counter') );


	/* Countdown Timer
	**************************************************************/
	if($('.countdown').length > 0) {
		$('.countdown').each(function(){

			var animation =  $(this).data('animation'),
					direction = $(this).data('direction'),
					circleFgWidth = $(this).data('fg-width'),
					circleBgWidth = $(this).data('bg-width'),
					circleBgColor = $(this).data('bg-color'),
					circleFgColorD = $(this).data('fg-color-days'),
					circleFgColorH = $(this).data('fg-color-hours'),
					circleFgColorM = $(this).data('fg-color-minutes'),
					circleFgColorS = $(this).data('fg-color-seconds'),
					circleDlabel = $(this).data('days-label'),
					circleHlabel = $(this).data('hours-label'),
					circleMlabel = $(this).data('minutes-label'),
					circleSlabel = $(this).data('seconds-label'),
					circleDshow = $(this).data('days-show'),
					circleHshow = $(this).data('hours-show'),
					circleMshow = $(this).data('minutes-show'),
					circleSshow = $(this).data('seconds-show');

			$(this).TimeCircles({
				animation: animation,
				direction: direction,
				fg_width: circleFgWidth,
				bg_width: circleBgWidth,
				circle_bg_color: circleBgColor,
				time: {
			    Days: {
			    	color: circleFgColorD,
			    	text: circleDlabel,
			    	show: circleDshow
			    },
			    Hours: {
			    	color: circleFgColorH,
			    	text: circleHlabel,
			    	show: circleHshow
			    },
			    Minutes: {
			    	color: circleFgColorM,
			    	text: circleMlabel,
			    	show: circleMshow
			    },
			    Seconds: {
			    	color: circleFgColorS,
			    	text: circleSlabel,
			    	show: circleSshow
			    }
				}
			});
		});
		$(window).resize(function(){
			$('.countdown').each(function(){
				$(this).TimeCircles().rebuild();
			});
		});
	}


	/* Rating System
	**************************************************************/
	if($('.rating-input input').length > 0) {
		$('.rating-input input').rating({
			starCaptions: 
			{
				0.5: '0.5 Star',
		    1: '1 Star',
		    1.5: '1.5 Star',
		    2: '2 Stars',
		    2.5: '2.5 Stars',
		    3: '3 Stars',
		    3.5: '3.5 Stars',
		    4: '4 Stars',
		    4.5: '4.5 Stars',
		    5: '5 Stars'
			},
			starCaptionClasses:
			{
		    0.5: 'label',
		    1: 'label',
		    1.5: 'label',
		    2: 'label',
		    2.5: 'label',
		    3: 'label',
		    3.5: 'label',
		    4: 'label',
		    4.5: 'label',
		    5: 'label'
			},
		});
	}

    
	/* Google Maps
	**************************************************************/
	if($('.google-map').length > 0) {
		$('.google-map').each(function(){
			var mapHeight = $(this).data('height'),
					address = $(this).data('address'),
					zoom = $(this).data('zoom'),
					controls = $(this).data('disable-controls'),
					scrollwheel = $(this).data('scrollwheel'),
					marker = $(this).data('marker'),
					markerTitle = $(this).data('marker-title'),
					styles = $(this).data('styles');
			$(this).height(mapHeight);
			$(this).parents('.map-collapse').css('max-height', mapHeight);
			$(this).gmap3({
          marker:{
            address: address,
            data: markerTitle,
            options: {
            	icon: marker
            },
            events: {
              mouseover: function(marker, event, context){
                var map = $(this).gmap3("get"),
                  	infowindow = $(this).gmap3({get:{name:"infowindow"}});
                if (infowindow){
                  infowindow.open(map, marker);
                  infowindow.setContent(context.data);
                } else {
                  $(this).gmap3({
                    infowindow:{
                      anchor:marker, 
                      options:{content: context.data}
                    }
                  });
                }
              },
              mouseout: function(){
                var infowindow = $(this).gmap3({get:{name:"infowindow"}});
                if (infowindow){
                  infowindow.close();
                }
              }
            }
          },
          map:{
            options:{
              zoom: zoom,
              disableDefaultUI: controls,
              scrollwheel: scrollwheel,
              styles: styles
            }
          }
			});
		});
	}

	/* Map Collapse
	**************************************************************/
	$('.map-collapse-toggle').on('click', function(){
		var collapseTitle = $(this).data('collapse-title'),
				expandTitle = $(this).data('expand-title');
		if($(this).parent().hasClass('closed')) {
			$(this).parent().removeClass('closed');
			$(this).find('span').text(collapseTitle);
		} else {
			$(this).parent().addClass('closed');
			$(this).find('span').text(expandTitle);
		}
	});


});/*Document Ready End*/////////////////////////////////////////////////////////////