/*global confused*/

(function ($) {
	if (!$.validator) {
		return;
	}

	$.validator.addMethod("requiredDropDown",

		function (value, element, defaultValue) {
			var comparison = defaultValue || "0";
			return element.value !== comparison;
		},
		"Please select an option."
	);

	$.validator.addMethod("regex",

		function (value, element, regexp) {
			return new RegExp(regexp).test(value);
		},
		"Please check your input."
	);

}(jQuery));

(function ($) {

	var defaultOptions,
		formRowClass = ".form-row";

	function addRemove(elem, add, remove) {
		var $elem = $(elem);
		$elem.addClass(add).removeClass(remove);
		$elem.closest(formRowClass).addClass(add).removeClass(remove);
	}

	defaultOptions = {
		debug : true,
		highlight: function (element, errorClass, validClass) {
			addRemove(element, errorClass, validClass);
		},
		unhighlight: function (element, errorClass, validClass) {
			addRemove(element, validClass, errorClass);
		},
		errorPlacement: function (error, element) {
			error.appendTo(element.closest(formRowClass));
		}
	};

	function bindElem(validator, $elem) {
		var data;

		if (!$elem.length) {
			return;
		}

		data = $elem.data();

		if (data.valMessages) {
			validator.settings.messages[$elem.attr("name")] = data.valMessages;
		}
		if (data.valRules) {
			$elem.rules("add", data.valRules);
		}
	}

	// bind all declarative validation rules
	function bind($form, options) {
		var settings, validator;

		if (!$form.length) {
			return;
		}

		if ($form.length > 1) {
			$form = $form.first();
		}

		settings = $.extend({}, defaultOptions, options);
		validator = $form.validate(settings);

		//for each validatable input
		$form.find(":input[data-val]").each(function () {
			var $this = $(this);
			bindElem(validator, $this);
		});
	}

	$(function() {
		var $form = $(".form").closest("form");
		bind($form);
	});

}(jQuery));