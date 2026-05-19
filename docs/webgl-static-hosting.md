# Unity WebGL Static Hosting

## Why this project is not using GitHub Pages

`Assets/Build/V1.0.1/Build/V1.0.1.data` is larger than GitHub's normal Git file limit, and GitHub Pages does not support Git LFS for runtime assets. This project therefore ships the latest WebGL build as a standalone static site package for object storage or other large-file-capable hosting.

Recommended providers:

- Alibaba Cloud OSS static website hosting
- Tencent Cloud COS static website hosting
- AWS S3 + CloudFront
- Cloudflare R2 + a Worker or another static delivery layer
- Any Nginx/Apache static server that allows files larger than 300 MB

## Build the upload package

From the project root, run:

```powershell
powershell -ExecutionPolicy Bypass -File .\tools\prepare-webgl-static-host.ps1 -Force
```

This produces:

- `.publish/webgl-v1.0.1/site`
- `.publish/webgl-v1.0.1/webgl-v1.0.1-static-host.zip`

The generated `site` directory is the exact content to upload to your host. The ZIP is only for convenient transfer.

## What to upload

Upload the contents of `.publish/webgl-v1.0.1/site` as the site root:

- `index.html`
- `Build/V1.0.1.data`
- `Build/V1.0.1.framework.js`
- `Build/V1.0.1.loader.js`
- `Build/V1.0.1.wasm`
- `Build/V1.0.1.jpg`

Do not upload the Unity project root, `Library`, `Temp`, old build folders, or `.git` content.

## Required host behavior

Your host must support:

- Static file delivery for single files larger than 300 MB
- `application/wasm` for `.wasm`
- Byte-range requests if the provider supports them
- HTTPS in production

Suggested MIME types:

| Extension | MIME type |
| --- | --- |
| `.html` | `text/html; charset=utf-8` |
| `.js` | `application/javascript` |
| `.wasm` | `application/wasm` |
| `.data` | `application/octet-stream` |
| `.jpg` | `image/jpeg` |

## Recommended verification after upload

Open the deployed URL and confirm:

- `index.html` loads successfully
- `Build/V1.0.1.data` returns `200`
- `Build/V1.0.1.wasm` returns `200` with `application/wasm`
- No asset URL returns a Git LFS pointer file
- The Unity loading screen reaches the first interactive frame

## Notes

- This package intentionally publishes only `V1.0.1`.
- Historical build folders stay in the Unity project and are not part of the deployment package.
- If you later create a compressed WebGL build with Unity's supported publishing pipeline, the same script can be adapted for `.unityweb` assets.
