export const impactTiersInfo = {
  0: {
    name: "No Impact",
    energy: "0 Joules",
    description: `Mass: < 10 kg
      Velocity: < 1 km/s
      Effects: It is just space dust.`,
  },
  1: {
    name: "Minimal Impact",
    energy: "10^6 to 10^9 Joules",
    description: `Mass: < 1000 kg
  Velocity: < 1 km/s
  Effects: Meteoroids of this size usually burn up in the atmosphere, causing little to no damage to Earth's surface.`,
  },
  2: {
    name: "Localized Damage",
    energy: "10^9 to 10^12 Joules",
    description: `Mass: 1000 kg to 10,000 kg
  Velocity: 1 km/s to 20 km/s
  Effects: Objects in this range might survive atmospheric entry and impact the Earth's surface, causing local damage like small craters or broken windows.`,
  },
  3: {
    name: "Continental Impact",
    energy: "10^12 to 10^15 Joules",
    description: `Mass: 10,000 kg to 1,000,000 kg
  Velocity: 20 km/s to 30 km/s
  Effects: Impacts in this range can cause widespread destruction on a continental scale, such as massive fires, dust clouds, and regional climate changes. The long-term effects may include ecosystem disruption and species extinction.`,
  },
  4: {
    name: "Global Catastrophe",
    energy: "10^15 to 10^20 Joules",
    description: `Mass: 1,000,000 kg to 10,000,000 kg
  Velocity: 30 km/s to 50 km/s
  Effects: These impacts can result in global catastrophes, including mass extinction events, prolonged climate changes, and severe disruption to the global ecosystem. The long-term consequences could be devastating for life on Earth.`,
  },
  5: {
    name: "Earth Destruction",
    energy: "10^20 Joules and above",
    description: `Mass: > 10,000,000 kg
  Velocity: > 50 km/s
  Effects: RIP.`,
  },
};
