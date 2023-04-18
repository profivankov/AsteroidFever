import anime from "animejs";

export const deformAsteroid = () => {
  anime({
    targets: [".moon"],
    translateX: function (el) {
      return el.getAttribute("data-x");
    },
    translateY: function (el, i) {
      return 50 + -50 * i;
    },
    scale: function (el, i, l) {
      return l - i + 0.25;
    },
    rotate: function () {
      return anime.random(-360, 360);
    },
    borderRadius: function () {
      return ["50%", anime.random(10, 35) + "%"];
    },
    duration: function () {
      return anime.random(1200, 1800);
    },
    delay: function () {
      return anime.random(0, 400);
    },
    direction: "alternate",
    loop: true,
  });
  anime({
    targets: [".moon"],
    scale: [
      { value: 0.1, easing: "easeOutSine", duration: 300 },
      { value: 1, easing: "easeInOutQuad", duration: 800 },
    ],
    delay: anime.stagger(200, { grid: [14, 5], from: "center" }),
    loop: true,
  });
};

export const hoverLogo = () => {
  anime({
    targets: document.getElementById("asteroidTitle"),
    translateY: ["-5px", "5px"],
    duration: 1800,
    direction: "alternate",
    loop: true,
    easing: "easeInOutSine",
  });
};
