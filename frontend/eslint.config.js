import antfu from "@antfu/eslint-config"
import nextPlugin from "@next/eslint-plugin-next"
import eslintConfigPrettier from "eslint-config-prettier/flat"
import globals from 'globals';

export default antfu(
  {
    react: true,
    typescript: true,
    lessOpinionated: true,
    languageOptions: {
      globals: {
        ...globals.node,
        ...globals.browser,
        process: "readonly",
      },
    },
    isInEditor: true,
    stylistic: {
      semi: true,
    },
    env: {
      node: true,
      browser: true,
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
      "n/no-process-env": "off",
      "test/padding-around-all": "error",
      "test/prefer-lowercase-title": "off",
    },
    ...eslintConfigPrettier,
  }
)
