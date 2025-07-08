import antfu from "@antfu/eslint-config"
import nextPlugin from "@next/eslint-plugin-next"
import eslintConfigPrettier from "eslint-config-prettier/flat"

export default antfu(
  {
    react: true,
    typescript: true,
    lessOpinionated: true,
    isInEditor: true,
    stylistic: {
      semi: true,
    },
    formatters: {
      css: true,
    },
    ignores: [
      "node_modules",
      "dist",
      "build",
      "coverage",
      ".next",
      ".turbo",
      "out",
      "public",
    ],
  },
  {
    plugins: {
      "@next/next": nextPlugin,
    },
    rules: {
      ...nextPlugin.configs.recommended.rules,
      ...nextPlugin.configs["core-web-vitals"].rules,
      "antfu/no-top-level-await": "off",
      "style/brace-style": ["error", "1tbs"],
      "ts/consistent-type-definitions": ["error", "type"],
      "react/prefer-destructuring-assignment": "off",
      "node/prefer-global/process": "off",
      "test/padding-around-all": "error",
      "test/prefer-lowercase-title": "off",
    },
    ...eslintConfigPrettier,
  }
)
