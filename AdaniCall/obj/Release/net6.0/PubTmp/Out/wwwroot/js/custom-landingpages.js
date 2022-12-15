filterSelection("all")
function filterSelection(c) {
  var x, i;
  x = document.getElementsByClassName("filterDiv");
  if (c == "all") c = "";
  // Add the "show" class (display:block) to the filtered elements, and remove the "show" class from the elements that are not selected
  for (i = 0; i < x.length; i++) {
    w3RemoveClass(x[i], "show");
    if (x[i].className.indexOf(c) > -1) w3AddClass(x[i], "show");
  }
}

// Show filtered elements
function w3AddClass(element, name) {
  var i, arr1, arr2;
  arr1 = element.className.split(" ");
  arr2 = name.split(" ");
  for (i = 0; i < arr2.length; i++) {
    if (arr1.indexOf(arr2[i]) == -1) {
      element.className += " " + arr2[i];
    }
  }
}

// Hide elements that are not selected
function w3RemoveClass(element, name) {
  var i, arr1, arr2;
  arr1 = element.className.split(" ");
  arr2 = name.split(" ");
  for (i = 0; i < arr2.length; i++) {
    while (arr1.indexOf(arr2[i]) > -1) {
      arr1.splice(arr1.indexOf(arr2[i]), 1);
    }
  }
  element.className = arr1.join(" ");
}

//// Add active class to the current control button (highlight it)
//var btnContainer = document.getElementById("myBtnContainer");
//var btns = btnContainer.getElementsByClassName("btn");
//for (var i = 0; i < btns.length; i++) {
//  btns[i].addEventListener("click", function() {
//    var current = document.getElementsByClassName("active");
//    current[0].className = current[0].className.replace(" active", "");
//    this.className += " active";
//  });
//}

$(function () {
    $(".paginate").paginga({/*use default options*/ });
    $(".paginate-page-2").paginga({ page: 2 });
    $(".paginate-no-scroll").paginga({ scrollToTop: false });
    $(".accordion").click(function () {
        var currentId = $(this).parent().attr("id");
        $(".panel").not($("#" + currentId).find(".panel").slideDown("slow")).slideUp("fast");
        $(".accordion").removeClass("active"); $("#" + currentId).find(".accordion").addClass("active");
    });
});

/* $('.iframe-video').each(function(index) {
  if(index == 0) {
    $(this).attr('src', $(this).attr('src'));
    return false;
  }
    
  if(index == 1) {
    $(this).attr('src', $(this).attr('src'));
    return false;
  }  
});

$("#video1")[0].src += "?autoplay=0";
$("#video2")[0].src += "?autoplay=0"; */


function conversationCall() {
    BootstrapDialog.confirm({
        title: 'Notice',
        id: "divConversationCall",
        size: BootstrapDialog.SIZE_WIDE,
        message: 'Your conversation with our agent will be recorded for training and quality purposes.',
        type: BootstrapDialog.TYPE_WARNING,
        closable: false,
        draggable: false,
        btnCancelLabel: 'Reject',
        btnOKLabel: 'Accept',
        btnCancelClass: 'btn btn-danger',
        btnOKClass: 'btn btn-success',
        callback: function (result) {
            // result will be true if button was click, while it will be false if users close the dialog directly.
            if (result) {
                window.location.href = '/Home/Call'
            }
        }
    });
}

function tnc() {
    BootstrapDialog.show({
        title: 'Terms And Conditions',
        id: "divTnC",
        size: BootstrapDialog.SIZE_EXTRAWIDE,
        type: getDialogType("PRIMARY"),
        message: function () {
            var $message = $('<div style="max-height: 1500px; overflow-y: scroll;"></div>');
            var html = '';
            html += '<div class="tnc-container" style="margin-top: 0px; box-shadow: none; padding: 0 0 0 10px;">';
            //html += '<header class= "site-header"> ';
            //html += '   <h1>Terms And Conditions</h1>';
            //html += '</header> ',
            html += '<p><strong>The User accepts this Terms and Conditions regarding access and use of the Digital Information Kiosk installed at the Airport and any services there to including without limitation features, functionalities, etc., offered by the Airport Operator.</strong></p>';
            html += '   <ol class="orderList mtop30">';
            html += '       <li>';
            html += '           <h1 class="title">Definitions</h1>';
            html += '           <p>"Airport" shall mean Adani Airport Holdings Limited;</p>';
            html += '           <p>"Airport Operator" shall mean Adani Airport Holdings Limited;</p>';
            html += '           <p>"Digital Screen(s)" shall mean touch-based Digital Information Kiosk installed at the Airport for Users to get information;</p>';
            html += '           <p>"Personal Data" shall mean the name, contact and other details provided by the User for accessing and using the Digital Screen;</p>';
            html += '           <p>"Terms" shall mean these Terms and Conditions;</p>';
            html += '           <p>"User(s)" means the person(s) who uses and access the Digital Screen(s).</p>';
            html += '       </li>';
            html += '       <li class="mtop30">';
            html += '           <h1 class="title">Access and Use of Digital Screen</h1>';
            html += '           <ul class="listDisc">';
            html += '               <li>User may access and use the Digital Screen installed at the Airport for getting information in accordance with the options as provided thereat.</li>';
            html += '               <li>In the process of interacting with the Airport Operator, User shall have the option to provide their Personal Data.</li>';
            html += '               <li>Thereafter, the conversation with the User and Airport Operator will be recorded for training and quality purposes.</li>';
            html += '           </ul>';
            html += '       </li>';
            html += '       <li class="mtop30">';
            html += '           <h1 class="title">Collection of Personal Data</h1>';
            html += '           <p>The Personal Data collected depends on how the User interacts through Digital Screen and the information provided to the Airport Operator. The User hereby consents to such collection and processing of Personal Data by the Airport Operator for its business and/ or meet its contractual and legal obligations or fulfill other legitimate interests.</p>';
            html += '       </li>';
            html += '       <li class="mtop30">';
            html += '           <h1 class="title">Use of Personal Data</h1>';
            html += '           <p>';
            html += '               Airport Operator and/ or its affiliates shall use the Personal Data for purposes described in the Terms herein. The Personal Data may be inter alia used to:',
            html += '               <ul class="listDisc">';
            html += '                   <li>provide and deliver services, including securing, troubleshooting, improving, and personalizing its products and services;</li>';
            html += '                   <li>operate and improve its business, including internal operations and security systems;</li>';
            html += '                   <li>understand User and his/ her preferences for enhancing User experience using Digital Screens;</li>';
            html += '                   <li>process User transactions;</li>';
            html += '                   <li>provide customer service and response to queries, if any;</li>';
            html += '                   <li>perform research and analysis aimed at improving its products, services and technologies;</li>';
            html += '                   <li>send information, including confirmations, invoices, technical notices, updates, security alerts, and support and administrative messages to Users;</li>';
            html += '                   <li>communicate about new products, offers, promotions, rewards, contests, upcoming events, and other information about its products and those of its selected partners; and</li>';
            html += '                   <li>display content, including advertising, that is customized to Users interests and preferences.</li>';
            html += '               </ul>';
            html += '           </p>';
            html += '           <p>In carrying out these purposes, Airport Operator may combine data collected from different sources to give Users more seamless, consistent, and personalized experience.</p>';
            html += '       </li>';
            html += '       <li class="mtop30">';
            html += '           <h1 class="title">Sharing of Personal Data</h1>';
            html += '           <p>User hereby consents for sharing the Personal Data to complete the transactions or provide the products or services requested or authorized, with third party agencies. Airport Operator may also share the Personal Data within its corporate group, including with its affiliates, and divisions, all of whom may use the Personal Data for the purposes disclosed herein.</p>';
            html += '           <p>Personal Data may also be shared with service providers who perform services on behalf of the Airport Operator. For example, Airport Operator may hire other companies to handle the processing of payments, to provide data storage, to provide technical support with respect to Digital Screens, to assist in direct marketing, analyses interests and preferences of Users and to conduct audits, etc. Those companies will be permitted to obtain only the Personal Data they need to provide the service. They are required to maintain the confidentiality of the information and are prohibited from using it for any other purpose.</p>';
            html += '           <p>Information about Users, including Personal Data, may be disclosed as part of any merger, transfer, divestiture, acquisition, or sale of all or a portion of the company and/or its assets, as well as in the unlikely event of insolvency, bankruptcy, or receivership, in which Personal Data would be transferred as one of the business assets of the company.</p>';
            html += '           <p>Airport Operator reserves the right to disclose Personal Data if required to do so by law (including to meet national security or law enforcement requirements), or in the good-faith belief that such action is reasonably necessary to comply with legal process, respond to claims, or protect the rights, property or safety of its employees, customers, or the public.</p>';
            html += '       </li>';
            html += '       <li class="mtop30">';
            html += '           <h1 class="title">Retention of Personal Data</h1>';
            html += '           <p>Personal Data may be retained by the Airport Operator even after the fulfillment of the transaction for other essential purposes such as complying with legal obligations, resolving disputes, and enforcing its agreements. Because these needs can vary for different data types in the context of different products, actual retention periods can vary significantly based on criteria such as user expectations or consent, the sensitivity of the data, the availability of automated controls that enable users to delete data, and our legal or contractual obligations.</p>';
            html += '       </li>';
            //html += '       <li class="mtop30">';
            //html += '           <h1 class="title">Social Media</h1>';
            //html += '           <p>Airport Operator may share the pictures of the Users clicked using Digital Screen with social networks like Facebook, etc. In these instances, User agrees that the data being shared is subject to the privacy policies of such social networks. Except where required by applicable law or regulation, Airport Operator does not control and does not assume any responsibility for the use of such data by social networks.</p>';
            //html += '       </li>';
            html += '       <li class="mtop30">';
            html += '           <h1 class="title">Security of Personal Data</h1>';
            html += '           <p>Airport Operator has taken appropriate and reasonable steps designed to help protect Personal Data from unauthorized access, use, disclosure, alteration, and destruction. For instance, in some cases the information in transit is encrypted using secure socket layer (SSL) technology. No method of transmission over the internet, or method of electronic storage, is 100% secure. Therefore, while Airport Operator strives to protect Personal Data, it cannot guarantee its absolute security.</p>';
            html += '       </li>';
            html += '       <li class="mtop30">';
            html += '           <h1 class="title">General</h1>';
            html += '           <div>';
            html += '               <ul class="listRoman">';
            html += '                   <li>Airport Operator reserves the right to add, change, discontinue, remove or suspend the access to Digital Screen, including its features and specifications, temporarily or permanently, at any time, without notice or intimation and without liability.</li>';
            html += '                   <li>Airport Operator reserves the right to undertake all necessary steps to ensure that the security, safety and integrity of Airport Operator\'s systems as well as its User interests are and remain, well - protected.</li>';
            html += '                   <li>Airport Operator reserves the right to change the Terms at any time it deems necessary to reflect changes in its products and services, or processing of Personal Data, or applicable law.</li>';
            html += '                   <li>Airport Operator reserves the right to take various steps to verify and confirm the authenticity, enforceability and validity of Personal Data shared by the User.</li>';
            html += '                   <li>The User shall have the option to not provide the Personal Data.</li>';
            html += '                   <li>These Terms shall be in addition to any other terms of use as provided by the Airport Operator at its website or otherwise and applicable hereto.</li>';
            html += '                   <li>The Personal Data submitted by the User may be adapted, broadcast, changed, copied, disclosed, licensed, performed, posted, published, transmitted or used by the Airport Operator anywhere in the world, in any medium, forever.</li>';
            html += '                   <li>Disputes, if any, shall be subject to Indian laws and shall be exclusively subject to the jurisdiction of the courts at India.</li>';
            html += '                   <li>These Terms are subject to the terms and conditions of the Concession Agreement between Airports Authority of India and Airport Operator dated February 14, 2020.</li>';
            html += '               </ul>';
            html += '           </div>';
            html += '       </li>';
            html += '   </ol>';
            html += '   <div class="clearfix"></div>';
            html += '</div>';
            $message.append(html);
            return $message;
        },        
        
        closable: true,
        draggable: false,
        buttons: [
            {
                label: "Cancel",
                action: function (dialog) {
                    dialog.close();
                }
            }
        ],
        onshown: function (dialogRef) {
            //
        }
    });
}