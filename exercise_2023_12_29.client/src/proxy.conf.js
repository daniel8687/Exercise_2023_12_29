const PROXY_CONFIG = [
  {
    context: [
      "/weatherforecast",
    ],
    target: "https://localhost:7279",
    secure: false
  },
  {
    context: [
      "/book",
    ],
    target: "https://localhost:7279",
    secure: false
  }
]

module.exports = PROXY_CONFIG;
